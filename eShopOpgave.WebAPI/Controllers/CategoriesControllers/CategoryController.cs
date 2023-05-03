using eShop.DataLayer.Entities;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
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

        /// <summary>
        /// Get Category by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Object</returns>
        [HttpGet("{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _productServices.GetCategoryById(id);
        }

        /// <summary>
        /// Create new Category.
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        [Route("Create")]
        public void AddCategory(CategoryDTO category)
        {
            _productServices.CreateCategory(category);

        }
    }
}
