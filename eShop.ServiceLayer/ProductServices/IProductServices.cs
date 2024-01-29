using eShop.DataLayer.Entities;
using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.Services
{
    public interface IProductServices
    {
        public Task AddProductAsync(ProductsDTO productDTO);
        public Task<Page<ProductsDTO>> GetAllProducts(int page, int count);
        public ProductsDTO GetProductById(int id);
        public Task UpdateProductAsync(ProductsDTO productDTO);
        public Task DeleteProductAsync(int id);
        public List<ProductsDTO> SearchProductByWord(string word);
        public Task<List<Category>> GetAllCategories();
    }
}
