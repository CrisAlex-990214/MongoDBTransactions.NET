namespace MongoDbTransactions.NET.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Base64Images { get; set; }
    }
}
