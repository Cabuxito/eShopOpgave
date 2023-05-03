using eShop.DataLayer.Entities;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopOpgave.WebAPI.Controllers.CategoriesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public CategoriesController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        /// <summary>
        /// Get a list of all Categories.
        /// </summary>
        /// <returns>Categories list</returns>
        [HttpGet]
        public async Task<List<Category>> GetCategories()
        {
            return await _productServices.GetAllCategories();
        }
    }
}
