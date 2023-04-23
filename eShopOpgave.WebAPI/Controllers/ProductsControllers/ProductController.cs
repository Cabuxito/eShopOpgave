using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopOpgave.WebAPI.Controllers.ProductsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public ProductsDTO GetProductById(int id)
        {
            ProductsDTO product = _productServices.GetProductById(id);
            if (product != null)
            {
                return product;
            }
            else
            {
                return product = new ProductsDTO();
            }
        }


        [HttpPost]
        public async Task CreateProduct(ProductsDTO newProduct)
        {
            await _productServices.AddProductAsync(newProduct);
        }


        [HttpPut]
        public async Task UpdateProductById(ProductsDTO productsDTO)
        {
            await _productServices.UpdateProductAsync(productsDTO);
        }

        [HttpDelete]
        public async Task DeleteProductById(int id)
        {
            await _productServices.DeleteProductAsync(id);
        }

    }
}
