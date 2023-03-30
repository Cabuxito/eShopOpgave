using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.Services
{
    public interface IProductServices
    {
        public Task AddProductAsync(ProductsDTO productDTO);
        public List<ProductsDTO> GetAllProducts();
        public Task UpdateProductAsync(ProductsDTO productDTO);
        public Task DeleteProductByIdAsync(int id);
    }
}
