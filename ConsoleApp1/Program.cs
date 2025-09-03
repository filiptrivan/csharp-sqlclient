using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string interactionsFilePath = @"C:\Users\user\Downloads\raw_interactions.csv";
            //string productsFilePath = @"C:\Users\user\Downloads\raw_products.csv";
            string apiUrl = @"http://127.0.0.1:5000";
            //string apiUrl = @"https://pa-recommender-fwa2hyepcqdrhre4.polandcentral-01.azurewebsites.net";

            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", "123");

                using (var formData = new MultipartFormDataContent())
                {
                    //var interactionsBytes = File.ReadAllBytes(interactionsFilePath);
                    //var interactionsContent = new ByteArrayContent(interactionsBytes);
                    //interactionsContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
                    //formData.Add(interactionsContent, "new_raw_interactions", Path.GetFileName(interactionsFilePath));

                    //var productsBytes = File.ReadAllBytes(productsFilePath);
                    //var productsContent = new ByteArrayContent(productsBytes);
                    //productsContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
                    //formData.Add(productsContent, "new_raw_products", Path.GetFileName(productsFilePath));

                    //var response = await httpClient.PostAsync(@$"{apiUrl}/train_model", formData);
                    var response = await httpClient.GetAsync(@$"{apiUrl}/train_homepage_and_similar_products_model_by_http_request");

                    string responseBody = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
                    
                    var content = await response.Content.ReadAsStringAsync();
                }
            }

            //HttpClient httpClient = new();
            //httpClient.DefaultRequestHeaders.Add("X-API-KEY", "123");

            //long userId = 52026;
            //string url = @$"{apiUrl}/get_recommendations?user_id={userId}";

            //HttpResponseMessage response = null;

            //response = await httpClient.GetAsync(url);
            //response.EnsureSuccessStatusCode();

            //List<ProductDTO> result = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();

            //foreach (ProductDTO productDTO in result)
            //{
            //    Console.WriteLine($"{productDTO.Id}     {productDTO.Active}     {productDTO.Status}     {productDTO.Stock}     {productDTO.Visibility}");
            //}
        }
    }
}

public class ProductDTO
{
    public string Id { get; set; } = null!;
    public string? Title { get; set; }
    public string? SKU { get; set; }
    public double? Price { get; set; }
    public int? Stock { get; set; }
    public string? Manufacturer { get; set; }
    public string? Category { get; set; }
    public string? Status { get; set; }
    public string? Visibility { get; set; }
    public bool? Active { get; set; }
}
