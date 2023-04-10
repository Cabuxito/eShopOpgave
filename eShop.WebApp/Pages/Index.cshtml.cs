using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductServices _productServices;

        public IndexModel(ILogger<IndexModel> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public List<ProductsDTO> Products { get; set; }

        public void OnGet()
        {
            Products = _productServices.GetAllProducts();
        }
    }
}