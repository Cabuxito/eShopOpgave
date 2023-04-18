
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

        public Page<ProductsDTO> Games { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; }

        public async Task OnGet(int page = 1, int count = 8)
        {
            Games = await _productServices.GetAllProductsPaging(page, count);
        }

        public async Task<IActionResult> OnPostSearch()
        {
            return RedirectToPage("/eShopPages/Products/Games", new { page = CurrentPage, count = PageSize});
        }
    }
}
