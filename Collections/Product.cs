using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTransactions.NET.Collections
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<string> Images { get; set; }
    }
}
