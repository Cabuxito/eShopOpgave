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

        public Page<ProductsDTO> Products { get; set; }

        public async Task OnGet(int page = 1, int count = 10)
        {
            Products = await _productServices.GetAllProducts(page, count);
        }
    }
}