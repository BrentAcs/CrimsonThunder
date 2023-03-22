using MongoDB.Bson.Serialization.Attributes;

namespace CrimsonThunder.Common.Infrastructure.Storage;

public interface IMongoDocument
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   [JsonConverter(typeof(ObjectIdConverter))]
   ObjectId Id { get; set; }
}