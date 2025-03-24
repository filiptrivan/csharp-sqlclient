namespace W.API.DTO
{
    public class ExternalProductDTO
    {
        public string Id { get; set; }

        public int Stock { get; set; }

        public string Status { get; set; }

        public string Visibility { get; set; }

        public bool Active { get; set; }

        public string Title { get; set; }

        public string Categories { get; set; }

        public string Manufacturer { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public decimal? Price { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImageUrl { get; set; }

        public string LinkToWebsite { get; set; }
    }
}
