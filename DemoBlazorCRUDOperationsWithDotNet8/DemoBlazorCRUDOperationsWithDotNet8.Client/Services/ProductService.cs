using SharedLibrary.Models;
using SharedLibrary.ProductRepositories;
using System.Net.Http.Json;
namespace DemoBlazorCRUDOperationsWithDotNet8.Client.Services
{
    public class ProductService : IProductRepository
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Product> AddProductAsync(Product model)
        {
            var product = await httpClient.PostAsJsonAsync("api/Product/Add-Product", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var product = await httpClient.DeleteAsync($"api/Product/Delete-Product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await httpClient.GetAsync("api/Product/All-Products");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response!;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await httpClient.GetAsync($"api/Product/Single-Product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var product = await httpClient.PutAsJsonAsync("api/Product/Update-Product", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }
    }
}
