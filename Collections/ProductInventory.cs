using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTransactions.NET.Collections
{
    public class ProductInventory
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Quantity { get; set; }
    }
}
