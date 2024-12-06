namespace W.API.DTO
{
    public class ExternalProductDTO
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public decimal? Price { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImageUrl { get; set; }

        public string LinkToWebsite { get; set; }
    }
}
