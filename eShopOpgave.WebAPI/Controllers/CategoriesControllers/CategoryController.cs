using eShop.DataLayer.Entities;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopOpgave.WebAPI.Controllers.CategoriesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public CategoryController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost]
        public void AddCategory (Category category)
        {
            if (category != null)
            {
                
            }
        }
    }
}
