using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Core.Pocos
{
    public class Member
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }

        // MogoDB 3.4, Support BsonDecimal128, Decimal (28-29)
        [BsonElement("balance"),BsonRepresentation(BsonType.Decimal128)]

        // Below than 3.4, only convert to Double (15-16)
        //[BsonElement("balance"), BsonRepresentation(BsonType.Double)]
        public decimal Balance { get; set; }
    }
}