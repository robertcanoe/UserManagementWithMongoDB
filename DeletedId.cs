using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class DeletedId
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
}