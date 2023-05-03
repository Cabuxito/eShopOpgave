using eShopOpgave.BlazorUI.Services.DTO;

namespace eShopOpgave.BlazorUI.Services.ProductServices
{
    public interface IProductAPIServices
    {
        Task<Item> CreateProduct(Item product);
        Task DeleteProductById(int id);
        Task<ProductsBase> GetAllProducts(int page, int count);
        Task<Item> GetProductById(int id);
    }
}