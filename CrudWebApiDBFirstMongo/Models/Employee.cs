using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CrudWebApiDBFirstMongo.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("department")]
        public string Department { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("salary")]
        public decimal Salary { get; set; }
    }
}
