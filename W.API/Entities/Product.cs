﻿using System.Xml.Linq;

namespace W.API.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public string LinkToWebsite { get; set; }
    }
}
