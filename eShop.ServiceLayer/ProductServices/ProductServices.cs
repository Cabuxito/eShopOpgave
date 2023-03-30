using eShop.DataLayer;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.Services
{
    public class ProductServices : IProductServices
    {
        private readonly eShopContext _context;

        public ProductServices (eShopContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(ProductsDTO productDTO)
        {
            _context.Products.Add(productDTO.ConvertFromDTOtoProduct());
            await _context.SaveChangesAsync();
        }

        public List<ProductsDTO> GetAllProducts() => _context.Products.ConvertProductsToProductsDTO().ToList();
        
        public async Task UpdateProductAsync(ProductsDTO productDTO)
        {
            _context.Products.Update(productDTO.ConvertFromDTOtoProduct());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            await _context.SaveChangesAsync();
        }
    }
}
