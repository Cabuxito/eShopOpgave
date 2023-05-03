using eShop.DataLayer.Entities;
using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.Services
{
    public interface IProductServices
    {
        public Task<ProductsDTO> AddProductAsync(ProductsDTO productDTO);
        public Task<Page<ProductsDTO>> GetAllProducts(int page, int count);
        public Task<ProductsDTO> GetProductById(int id);
        public Task UpdateProductAsync(ProductsDTO productDTO);
        public Task DeleteProductAsync(int id);
        public List<ProductsDTO> SearchProductByWord(string word);


        public Task<Category> GetCategoryById(int id);
        public Task<List<Category>> GetAllCategories();
        public Task CreateCategory(CategoryDTO category);
    }
}
