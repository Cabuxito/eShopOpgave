using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.WebApp.Pages.eShopPages.Products
{
    public class GamesModel : PageModel
    {

        private readonly IProductServices _productServices;

        public GamesModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public List<ProductsDTO> Games { get; set; }

        public async Task OnGet()
        {
            Games = await _productServices.GetAllProducts();
        }
    }
}
