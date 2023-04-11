using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.Services
{
    public interface IProductServices
    {
        public Task AddProductAsync(ProductsDTO productDTO);
        public Task<List<ProductsDTO>> GetAllProducts();
        public Task UpdateProductAsync(ProductsDTO productDTO);
        public Task DeleteProductAsync(int id);
        public List<ProductsDTO> SearchProductByWord(string word);
    }
}
