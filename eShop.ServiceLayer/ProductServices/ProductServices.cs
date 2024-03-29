﻿using eShop.DataLayer;
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

        public async Task AddProductAsync(ProductsDTO productDTO)
        {
            _context.Products.Add(productDTO.ConvertFromDTOtoProduct());
            await _context.SaveChangesAsync();
        }

        public async Task<Page<ProductsDTO>> GetAllProducts(int page, int count)
        {
           IQueryable<Product> query = _context.Products.Include(x => x.Category).AsNoTracking();
           Page<ProductsDTO> productPage = new Page<ProductsDTO>();
           return new Page<ProductsDTO> { Total = query.Count(), Items = query.Page(page, count).ConvertProductsToProductsDTO().ToList(), CurrentPage = page, PageSize = count };
        }    

        public ProductsDTO GetProductById(int id)
        {
            return (ProductsDTO)_context.Products.AsNoTracking().Where(x => x.ProductId == id).ConvertProductsToProductsDTO();
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
        
        public async Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
