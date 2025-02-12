using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Counter
{
    [BsonId]
    [BsonRepresentation(BsonType.String)] // Asegúrate de que el ID sea una cadena, no un ObjectId
    public string Id { get; set; } = string.Empty;

    [BsonElement("sequenceValue")] // Asegúrate de que el nombre del campo coincida exactamente con el nombre en la base de datos
    public int SequenceValue { get; set; }
}