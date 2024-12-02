using Microsoft.AspNetCore.Mvc;
using W.API.DTO;
using W.API.Entities;
using W.API.Services;

namespace W.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly FakeDbService _dbService;
        private readonly FakeSyncService _syncService;

        public WeatherForecastController()
        {
            _dbService = new FakeDbService();
            _syncService = new FakeSyncService();
        }

        [HttpGet]
        public List<ExternalTransactionDTO> GetTransactionList(DateTime dateFrom, DateTime dateTo)
        {
            List<Transaction> transactions = _dbService.GetTransactionList().Where(x => x.CreatedAt > dateFrom && x.CreatedAt <= dateTo).ToList();

            return transactions
                .Select(x => new ExternalTransactionDTO
                {
                    Code = x.Code, // FT: Uniquely defines the transaction
                    UserEmail = x.UserEmail,
                    ProductName = x.ProductName,
                    ProductImageUrl = null,
                    ProductCategoryName = x.ProductCategoryName,
                    ProductCategoryImageUrl = null,
                    Price = x.Price,
                    BoughtAt = x.CreatedAt,
                })
                .ToList();
        }

        /// <summary>
        /// Created a method so that I could update the points for an individual user if something went wrong in the auto-update (scheduled task)
        /// </summary>
        [HttpGet]
        public List<ExternalTransactionDTO> GetTransactionListForTheUser(string userEmail, DateTime dateFrom, DateTime dateTo)
        {
            List<Transaction> transactions = _dbService.GetTransactionList().Where(x => x.CreatedAt > dateFrom && x.CreatedAt <= dateTo && x.UserEmail == userEmail).ToList();

            return transactions
                .Select(x => new ExternalTransactionDTO
                {
                    Code = x.Code,
                    UserEmail = x.UserEmail,
                    ProductName = x.ProductName,
                    ProductImageUrl = null,
                    ProductCategoryName = x.ProductCategoryName,
                    ProductCategoryImageUrl = null,
                    Price = x.Price,
                    BoughtAt = x.CreatedAt,
                })
                .ToList();
        }

        [HttpPut]
        public void SaveUser(ExternalUserDTO externalUserDTO)
        {
            List<User> users = _dbService.GetUserList();

            User user = users.Where(x => x.Email == externalUserDTO.Email).SingleOrDefault();

            Tier tier = _dbService.GetTierList().Where(x => x.Code == externalUserDTO.TierCode).SingleOrDefault();

            if (tier == null) 
            {
                _syncService.SyncTiers();

                tier = _dbService.GetTierList().Where(x => x.Code == externalUserDTO.TierCode).SingleOrDefault();

                if (tier == null)
                    throw new Exception("U sistemu ne postoji traženi nivo lojalnosti ni nakon sinhronizacije podataka.");
            }

            if (user == null)
            {
                // FT: I'm not sending you the password because there won't even be a password in my system, if you need it to save the user, maybe you can generate a random one, so let him change it when he logs in for the first time.
                User newUser = new User
                {
                    Email = externalUserDTO.Email,
                    Points = externalUserDTO.Points,
                    Tier = tier,
                };

                _dbService.SaveUser(newUser);
            }
            else
            {
                user.Points = externalUserDTO.Points;
                user.Tier = tier;

                _dbService.UpdateUser(user);
            }
        }

        /// <summary>
        /// I use these categories to show them to the admin on PL and so that he can assign discounts for different loyalty levels for these categories
        /// </summary>
        [HttpGet]
        public List<ExternalDiscountCategoryDTO> GetDiscountCategoryList()
        {
            List<ProductCategory> categories = _dbService.GetProductCategoryList();

            return categories
                .Select(x => new ExternalDiscountCategoryDTO
                {
                    Name = x.Name,
                    Code = x.Code, // FT: Uniquely defines the category
                })
                .ToList();
        }

        //[HttpPut]
        //public void SaveTiers(ExternalTierDTO)
        //{

        //}
    }
}
