using System.Text.Json;
using Ecommerce.ViewModels;

namespace Ecommerce.CustomerFe.Services.Product
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5008");
        }

        public async Task<IList<ProductVm>> GetProducts(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("api/v1/products");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var productList = JsonSerializer.Deserialize<IList<ProductVm>>(content)!;

            return productList;
        }
    }
}