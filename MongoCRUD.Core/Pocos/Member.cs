using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Core.Pocos
{
    public class Member
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("balance")]
        public decimal Balance { get; set; }
    }
}