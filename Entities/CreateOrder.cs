namespace MongoDbTransactions.NET.Entities
{
    public class CreateOrder
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
    }
}
