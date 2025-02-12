using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;
    private readonly IMongoCollection<Counter> _countersCollection;
    private readonly IMongoCollection<DeletedId> _deletedIdsCollection;

    public UserService(IMongoCollection<User> usersCollection, IMongoCollection<Counter> countersCollection, IMongoCollection<DeletedId> deletedIdsCollection)
    {
        _usersCollection = usersCollection;
        _countersCollection = countersCollection;
        _deletedIdsCollection = deletedIdsCollection;
    }

    public void CrearUsuario(string username, string email)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            throw new ArgumentException("Los campos no pueden estar vacíos.");

        if (!IsValidEmail(email))
            throw new ArgumentException("El email no tiene un formato válido (debe ser usuario@dominio.ext).");

        var emailExists = _usersCollection.Find(u => u.Email == email).FirstOrDefault();
        if (emailExists != null)
            throw new ArgumentException("El correo ya está registrado.");

        string customId;

        var deletedId = _deletedIdsCollection.Find(_ => true).FirstOrDefault();
        if (deletedId != null)
        {
            customId = deletedId.Id;
            _deletedIdsCollection.DeleteOne(Builders<DeletedId>.Filter.Eq(d => d.Id, customId));
        }
        else
        {
            var filter = Builders<Counter>.Filter.Eq(c => c.Id, "userId");
            var update = Builders<Counter>.Update.Inc(c => c.SequenceValue, 1);
            var options = new FindOneAndUpdateOptions<Counter> { ReturnDocument = ReturnDocument.After, IsUpsert = true };
            var counter = _countersCollection.FindOneAndUpdate(filter, update, options);
            customId = counter.SequenceValue.ToString("D4");
        }

        var usuario = new User { CustomId = customId, Username = username, Email = email };
        _usersCollection.InsertOne(usuario);
    }

    public List<User> ListarUsuarios()
    {
        return _usersCollection.Find(_ => true).ToList();
    }

    public void ActualizarUsuario(string customId, string nuevoUsername, string nuevoEmail)
    {
        var usuario = _usersCollection.Find(u => u.CustomId == customId).FirstOrDefault();
        if (usuario == null)
            throw new ArgumentException("Usuario no encontrado.");

        var updateDefinition = Builders<User>.Update;
        var update = new List<UpdateDefinition<User>>();

        if (!string.IsNullOrEmpty(nuevoUsername))
        {
            update.Add(updateDefinition.Set(u => u.Username, nuevoUsername));
        }

        if (!string.IsNullOrEmpty(nuevoEmail))
        {
            if (!IsValidEmail(nuevoEmail))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            if (_usersCollection.Find(u => u.Email == nuevoEmail).Any())
                throw new ArgumentException("El email ya está en uso.");

            update.Add(updateDefinition.Set(u => u.Email, nuevoEmail));
        }

        if (update.Count > 0)
        {
            var combinedUpdate = updateDefinition.Combine(update);
            var filter = Builders<User>.Filter.Eq(u => u.CustomId, customId);
            _usersCollection.UpdateOne(filter, combinedUpdate);
        }
    }

    public void EliminarUsuario(string customId)
    {
        var usuario = _usersCollection.Find(u => u.CustomId == customId).FirstOrDefault();
        if (usuario == null)
            throw new ArgumentException("Usuario no encontrado.");

        var filter = Builders<User>.Filter.Eq(u => u.CustomId, customId);
        _usersCollection.DeleteOne(filter);

        var deletedId = new DeletedId { Id = customId };
        _deletedIdsCollection.InsertOne(deletedId);
    }

    private bool IsValidEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
}