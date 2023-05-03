using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopOpgave.WebAPI.Controllers.ProductsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        /// <summary>
        /// Get List of all products in DB.
        /// </summary>
        /// <returns>Product Object</returns>
        [HttpGet]
        public async Task<Page<ProductsDTO>> GetProducts(int page, int count)
        {
            return await _productServices.GetAllProducts(page, count);
        }

        /// <summary>
        /// Get a List of products by search title.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>list of products</returns>
        [HttpGet]
        [Route("Search:string")]
        public ActionResult<List<ProductsDTO>> SearchProducts(string searchString) => _productServices.SearchProductByWord(searchString);
    }
}
