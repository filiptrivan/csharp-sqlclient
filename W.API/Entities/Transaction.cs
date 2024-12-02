namespace W.API.Entities
{
    public class Transaction
    {
        public string Code { get; set; }
        public string UserEmail { get; set; }

        public string ProductName { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductCategoryName { get; set; }

        public string ProductCategoryImageUrl { get; set; }

        public decimal? Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
