
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudWebApiCodeFirstMongo.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; } = null!;

        [BsonElement("author")]
        public string Author { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
