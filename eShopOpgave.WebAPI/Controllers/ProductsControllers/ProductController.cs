using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Components.Forms;
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

        /// <summary>
        /// Get Product by ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Product Object</returns>
        [HttpGet()]
        [Route("Get/{id:int}")]
        public async Task<ActionResult<ProductsDTO>> GetProductById(int id) => await _productServices.GetProductById(id);

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="newProduct"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///         "masterKey": 0,
        ///         "title": "Test",
        ///         "description": "Test",
        ///         "price": 100,
        ///         "stock": 100,
        ///         "manufacture": "TestOfTest",
        ///         "imgPath": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [Route("Create")]
        public async Task<ProductsDTO> CreateProduct(ProductsDTO newProduct) => await _productServices.AddProductAsync(newProduct);
         
        /// <summary>
        /// Update product by ID.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///         "masterKey": "Product ID",
        ///         "title": "New Title",
        ///         "description": "New Description",
        ///         "price": 100,
        ///         "stock": 100,
        ///         "manufacture": "TestOfTest",
        ///         "imgPath": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPut]
        [Route("Update")]
        public async Task UpdateProductById(ProductsDTO productsDTO) => await _productServices.UpdateProductAsync(productsDTO);

        /// <summary>
        /// Delete Product By ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteProductById(int id) => await _productServices.DeleteProductAsync(id);

    }
}
