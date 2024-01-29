using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.WebApp.Pages.eShopPages.Products
{
    public class SearchModel : PageModel
    {
        private readonly IProductServices _services;

        public SearchModel(IProductServices services)
        {
            _services = services;
        }

        public List<ProductsDTO> FindProducts { get; set; }

        public void OnGet(string SearchWord)
        {
            FindProducts = _services.SearchProductByWord(SearchWord);
        }
    }
}
