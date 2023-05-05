using eShopOpgave.BlazorUI.Services.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShopOpgave.BlazorUI.Services.ProductServices
{
    public class ProductAPIServices : IProductAPIServices
    {
        private readonly HttpClient _httpClient;

        public ProductAPIServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductsBase> GetAllProducts(int page, int count)
        {
            ProductsBase item = await _httpClient.GetFromJsonAsync<ProductsBase>($"/api/Products/?page={page}&count={count}");

            if (item != null)
            {
                return item;
            }
            throw new KeyNotFoundException("Item does not exist");
        }

        public async Task<Item> CreateProduct(Item product)
        {
            var response = await _httpClient.PostAsJsonAsync<Item>("/api/Product/Create", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Item>();
        }

        public async Task<Item> GetProductById(int id)
        {
            Item? product = await _httpClient.GetFromJsonAsync<Item>($"/api/Product/Get/{id}");
            if (product != null)
            {
                return product;
            }
            throw new KeyNotFoundException("Item Not Found");
        }

        public async Task DeleteProductById(int id)
        {
            await _httpClient.DeleteAsync($"/api/Product/Delete/?id={id}");
        }

        public async Task<ProductsBase> Search(string word)
        {
            return await _httpClient.GetFromJsonAsync<ProductsBase>($"/api/Search:{word}");
        }
    }
}
