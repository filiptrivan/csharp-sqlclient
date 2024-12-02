
namespace PA.MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.MapPut("/SaveUser", (HttpContext httpContext) =>
            {
                //UserDTO userDTO = httpContext.Request.Body();

                //string userEmail = userDTO.Email;
                //int points = userDTO.Points;
                //int tierCode = userDTO.TierCode;

                //User user = DB.Users.Where(x => x.Email == userEmail).SingleOrDefault();
                //Tier tier = DB.Tiers.Where(x => x.TierCode == tierCode).SingleOrDefault();

                //if (tier == null)
                //{
                //    SyncTiers();

                //    tier = DB.Tiers.Where(x => x.TierCode == tierCode).SingleOrDefault();
                //}

                //if (user == null)
                //{
                //    DB.Save(user);
                //}
                //else
                //{
                //    DB.Update(user);
                //}
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}
