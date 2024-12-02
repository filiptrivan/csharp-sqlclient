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
                new User { Id = 1, Email = "john.doe@example.com", Points = 1200, TierCode = "GOLD", TierId = 1 },
                new User { Id = 2, Email = "jane.smith@example.com", Points = 300, TierCode = "SILVER", TierId = 2 },
                new User { Id = 3, Email = "mark.johnson@example.com", Points = 50, TierCode = "BRONZE", TierId = 3 },
                new User { Id = 4, Email = "lucy.brown@example.com", Points = 2500, TierCode = "PLATINUM", TierId = 4 },
                new User { Id = 5, Email = "michael.green@example.com", Points = 800, TierCode = "SILVER", TierId = 2 },
                new User { Id = 6, Email = "susan.wilson@example.com", Points = 5000, TierCode = "DIAMOND", TierId = 5 },
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
            return new List<ProductCategory> { };
        }
    }
}
