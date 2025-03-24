using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using W.API.DTO;
using W.API.Entities;
using W.API.Services;

namespace W.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class PlayertyLoyalsController : ControllerBase
    {
        private readonly FakeDbService _dbService;
        private readonly FakeSyncService _syncService;
        private readonly HttpClient _httpClient;

        public PlayertyLoyalsController()
        {
            _dbService = new FakeDbService();
            _syncService = new FakeSyncService();
            _httpClient = new HttpClient();
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
        public async Task SaveUser(ExternalUserDTO externalUserDTO)
        {
            List<User> users = _dbService.GetUserList();

            User user = users.Where(x => x.Email == externalUserDTO.Email).SingleOrDefault();

            Tier tier = _dbService.GetTierList().Where(x => x.Code == externalUserDTO.TierCode).SingleOrDefault();

            // FT: We shouldn't throw exception immediately, because if the user is making new partner user profile, it is not his fault that someone deleted the tier from the partner's application.
            if (tier == null) 
            {
                await SyncTiers();

                tier = _dbService.GetTierList().Where(x => x.Code == externalUserDTO.TierCode).SingleOrDefault();

                if (tier == null)
                    throw new Exception("U sistemu ne postoji prosleđeni nivo lojalnosti, ni nakon ažuriranja.");
            }

            if (user == null)
            {
                // FT: I'm not sending you the password because there won even be a password in my system, if you need it to save the user, maybe you can generate a random one, so let him change it when he logs in for the first time.
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

        [HttpPut]
        public void SaveTiers(List<ExternalTierDTO> externalTierDTOList)
        {
            List<Tier> tierList = _dbService.GetTierList();

            foreach (ExternalTierDTO externalTierDTO in externalTierDTOList)
            {
                Tier tier = tierList.Where(x => x.Code == externalTierDTO.Code).SingleOrDefault();

                if (tier == null)
                {
                    Tier newTier = new Tier
                    {
                        Code = externalTierDTO.Code,
                        Name = externalTierDTO.Name,
                        DiscountProductCategories = GetDiscountProductCategoriesForExternalDiscountCategories(externalTierDTO.ExternalDiscountCategoryDTOList)
                    };

                    _dbService.SaveTier(newTier);
                }
                else
                {
                    tier.Name = externalTierDTO.Name;
                    tier.DiscountProductCategories = GetDiscountProductCategoriesForExternalDiscountCategories(externalTierDTO.ExternalDiscountCategoryDTOList);

                    _dbService.UpdateTier(tier);
                }
            }
        }

        /// <summary>
        /// If there is no 9 element, PL will throw exception.
        /// TODO: When we make recommendation system, i will pass you the ExternalUserDTO as argument, but for now, give me the nine products which you think are the best.
        /// </summary>
        /// <returns>List<ExternalProductDTO> of nine elements</returns>
        [HttpGet]
        public List<ExternalProductDTO> GetRecommendationProductList()
        {
            return _dbService.GetProductList()
                .Select(x => new  ExternalProductDTO
                {
                    Title = x.Name,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Code = x.Code,
                    Price = x.Price,
                    CategoryName = x.Category.Name,
                    CategoryImageUrl = x.Category.ImageUrl,
                    LinkToWebsite = x.LinkToWebsite,
                })
                .Take(9)
                .ToList();
        }

        [HttpGet]
        public List<ExternalProductDTO> GetProducts()
        {
            List<ExternalProductDTO> products = new();

            for (int i = 0; i < 70000; i++)
            {
                products.Add(new ExternalProductDTO
                {
                    Id = $"SKU {i}",
                    Stock = i,
                    Status = "Published",
                    Visibility = "Public",
                    Active = true,
                    Title = $"Product {i}",
                    CategoryImageUrl = $"CIU {i}",
                    CategoryName = $"CN {i}",
                    Code = $"Code {i}",
                    Description = $"Desc {i}",
                    ImageUrl = $"Image URL {i}",
                    LinkToWebsite = $"LTW {i}",
                    Price = i
                });
            }

            return products;
        }

        [HttpGet]
        public List<InteractionDTO> GetInteractions()
        {
            List<InteractionDTO> products = new();

            for (int i = 0; i < 500_000; i++)
            {
                products.Add(new InteractionDTO
                {
                    ProductId = $"SKU {GetRandomNumber(80_000)}",
                    UserId = $"Email {GetRandomNumber(10_000)}",
                    Interaction = GetRandomInteraction(),
                    Timestamp = GetRandomDateInTheLastYear()
                });
            }

            return products;
        }

        #region Helpers

        private async Task SyncTiers()
        {
            HttpResponseMessage response = null;

            try
            {
                response = await _httpClient.GetAsync("https://playerty-loyals.vercel.app/GetTiers");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                HandleExternalApiException(ex);
            }

            List<ExternalTierDTO> externalTierDTOList = await response.Content.ReadFromJsonAsync<List<ExternalTierDTO>>();

            SaveTiers(externalTierDTOList);
        }

        private void HandleExternalApiException(Exception ex)
        {
            if (ex is HttpRequestException)
            {
                throw new Exception("Došlo je do greške prilikom HTTP zahteva. Proverite URL i mrežnu konekciju.");
            }
            else if (ex is TaskCanceledException timeoutEx && !timeoutEx.CancellationToken.IsCancellationRequested)
            {
                throw new Exception("Zahtev je istekao. Proverite mrežnu konekciju servera.");
            }
            else if (ex is TaskCanceledException canceledEx && canceledEx.CancellationToken.IsCancellationRequested)
            {
                throw new Exception("Zahtev je otkazan. Proverite da li je zahtev ručno prekinut ili pokušajte ponovo.");
            }
            else if (ex is InvalidOperationException)
            {
                throw new Exception("Došlo je do greške u konfiguraciji klijenta ili zahteva. Obratite se podršci.");
            }
            else if (ex is OperationCanceledException)
            {
                throw new Exception("Operacija je prekinuta. Pokušajte ponovo.");
            }
            else
            {
                throw new Exception("Došlo je do neočekivane greške. Obratite se podršci.");
            }
        }
        /// <summary>
        /// I made this just to make it uniform so as not to complicate the example, you will definitely need to modify it
        /// </summary>
        private List<DiscountProductCategory> GetDiscountProductCategoriesForExternalDiscountCategories(List<ExternalDiscountCategoryDTO> externalDiscountCategoryDTOList)
        {
            List<ProductCategory> productCategoryList = _dbService.GetProductCategoryList();

            return externalDiscountCategoryDTOList
                .Select(x =>
                {
                    ProductCategory productCategory = productCategoryList.Where(pc => pc.Code == x.Code).SingleOrDefault();

                    if (productCategory == null)
                        throw new Exception("Iz aplikacije PL, neko pokušava da hakuje sistem i da pošalje neku kategoriju koju partner nema u svom sistemu.");

                    return new DiscountProductCategory
                    {
                        Discount = x.Discount,
                        ProductCategory = productCategory,
                    };
                })
                .ToList();
        }

        private long GetRandomNumber(int range)
        {
            return new Random().Next(range);
        }

        private string GetRandomInteraction()
        {
            string[] interactions = { "Bought", "PutInCart", "PutInFavorites", "Clicked" };
            int index = new Random().Next(interactions.Length);
            return interactions[index];
        }

        private string GetRandomDateInTheLastYear()
        {
            Random random = new Random();

            int daysAgo = random.Next(0, 365);
            int hours = random.Next(0, 24);
            int minutes = random.Next(0, 60);
            int seconds = random.Next(0, 60);

            TimeSpan timeSpan = new TimeSpan(daysAgo, hours, minutes, seconds);

            DateTime randomDate = DateTime.Now;

            return randomDate.ToString("dd.MM.yyyy. HH:mm:ss");
        }

        #endregion
    }
}
