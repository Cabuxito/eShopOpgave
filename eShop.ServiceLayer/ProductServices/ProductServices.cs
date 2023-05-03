using eShop.DataLayer;
using eShop.DataLayer.Entities;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.ModelsDTO.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eShop.ServiceLayer.Services
{
    public class ProductServices : IProductServices
    {
        private readonly eShopContext _context;

        public ProductServices (eShopContext context)
        {
            _context = context;
        }

        public async Task<ProductsDTO> AddProductAsync(ProductsDTO productDTO)
        {
            var product = productDTO.ConvertFromDTOtoProduct();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ConvertProductsToProductsDTO();
        }

        public async Task<Page<ProductsDTO>> GetAllProducts(int page, int count)
        {
           IQueryable<Product> query = _context.Products.Include(x => x.Category).AsNoTracking();
           Page<ProductsDTO> productPage = new Page<ProductsDTO>();
           return new Page<ProductsDTO> { Total = query.Count(), Items = query.Page(page, count).ConvertProductsToProductsDTO().ToList(), CurrentPage = page, PageSize = count };
        }    

        public async Task<ProductsDTO> GetProductById(int id)
        {
            return await _context.Products.AsNoTracking().Where(x => x.ProductId == id).ConvertProductsToProductsDTO().FirstOrDefaultAsync();
        }

        public async Task UpdateProductAsync(ProductsDTO productDTO)
        {
            Product? Oldproduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == productDTO.MasterKey);
            Oldproduct = productDTO.ConvertFromDTOtoProduct();

            _context.Products.Update(Oldproduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            await _context.SaveChangesAsync();
        }

        public List<ProductsDTO> SearchProductByWord(string word)
        {
            return _context.Products.AsNoTracking().Where(x => x.Title.Contains(word)).ConvertProductsToProductsDTO().ToList();
        }


        #region Category

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.AsNoTracking().Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public async Task CreateCategory(CategoryDTO category)
        {
            _context.Categories.Add(category.ConvertFromDTOtoCategory());
            _context.SaveChanges();
        }
        #endregion
    }
}
