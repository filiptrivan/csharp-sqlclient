using W.API.Entities;

namespace W.API.Services
{
    public class FakeDbService
    {
        public FakeDbService()
        {

        }

        public List<Transaction> GetTransactionList()
        {
            return new List<Transaction>
            {
                new Transaction
                {
                    UserEmail = "john.doe@example.com",
                    ProductName = "Cordless Drill",
                    ProductImageUrl = null,
                    ProductCategoryName = "Power Tools",
                    ProductCategoryImageUrl = "https://example.com/images/power-tools.jpg",
                    Price = 89.99m,
                    CreatedAt = DateTime.Now.AddSeconds(-50)
                },
                new Transaction
                {
                    UserEmail = "jane.smith@example.com",
                    ProductName = "Circular Saw",
                    ProductImageUrl = "https://example.com/images/circular-saw.jpg",
                    ProductCategoryName = "Power Tools",
                    ProductCategoryImageUrl = "https://example.com/images/power-tools.jpg",
                    Price = 129.50m,
                    CreatedAt = DateTime.Now.AddSeconds(-50)
                },
                new Transaction
                {
                    UserEmail = "alex.jones@example.com",
                    ProductName = "Gardening Gloves",
                    ProductImageUrl = "https://example.com/images/gardening-gloves.jpg",
                    ProductCategoryName = "Gardening",
                    ProductCategoryImageUrl = "https://example.com/images/gardening.jpg",
                    Price = 15.75m,
                    CreatedAt = DateTime.Now.AddSeconds(-50)
                },
                new Transaction
                {
                    UserEmail = "maria.garcia@example.com",
                    ProductName = "Lawn Mower",
                    ProductImageUrl = null,
                    ProductCategoryName = "Gardening",
                    ProductCategoryImageUrl = "https://example.com/images/gardening.jpg",
                    Price = 249.99m,
                    CreatedAt = DateTime.Now.AddSeconds(-50)
                },
                new Transaction
                {
                    UserEmail = "li.wei@example.com",
                    ProductName = "Paint Roller",
                    ProductImageUrl = "https://example.com/images/paint-roller.jpg",
                    ProductCategoryName = "Painting Supplies",
                    ProductCategoryImageUrl = "https://example.com/images/painting-supplies.jpg",
                    Price = 12.99m,
                    CreatedAt = DateTime.Now.AddSeconds(-50)
                }
            };
        }

        public List<User> GetUserList()
        {
            return new List<User>
            {
                new User { Id = 1, Email = "john.doe@example.com", Points = 1200 },
                new User { Id = 2, Email = "jane.smith@example.com", Points = 300 },
                new User { Id = 3, Email = "mark.johnson@example.com", Points = 50 },
                new User { Id = 4, Email = "lucy.brown@example.com", Points = 2500 },
                new User { Id = 5, Email = "michael.green@example.com", Points = 800 },
                new User { Id = 6, Email = "susan.wilson@example.com", Points = 5000 },
            };
        }

        public void SaveUser(User user) { }

        public void UpdateUser(User user) { }

        public List<Tier> GetTierList()
        {
            return new List<Tier> { };
        }

        public List<ProductCategory> GetProductCategoryList()
        {
            return new List<ProductCategory>
            {
                new ProductCategory { Name = "Bosch", Code = "B-H-2024" },
                new ProductCategory { Name = "Makita", Code = "M-D-2024" },
                new ProductCategory { Name = "DeWalt", Code = "D-S-2024" },
                new ProductCategory { Name = "Stanley", Code = "S-H-2024" },
                new ProductCategory { Name = "Bosch", Code = "B-G-2024" },
                new ProductCategory { Name = "Milwaukee", Code = "M-I-2024" },
                new ProductCategory { Name = "Black+Decker", Code = "B-J-2024" },
                new ProductCategory { Name = "Hilti", Code = "H-L-2024" },
                new ProductCategory { Name = "Ryobi", Code = "R-C-2024" },
                new ProductCategory { Name = "TestNew", Code = "T-N-2024" },
            };
        }

        public List<Product> GetProductList()
        {
            return new List<Product> { };
        }

        public void SaveTier (Tier tier) { }

        public void UpdateTier (Tier tier) { }
    }
}
