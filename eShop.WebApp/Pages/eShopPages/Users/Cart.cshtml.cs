using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using eShop.WebApp.SessionHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace eShop.WebApp.Pages.eShopPages.Users
{
    public class CartModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly ICustomerServices _customerServices;

        public CartModel(IProductServices productServices, ICustomerServices customerServices)
        {
            _productServices = productServices;
            _customerServices = customerServices;
        }

        public List<ShoppingCartHelper> CartItems { get; set; }

        public void OnGet()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(cartJson))
            {
                CartItems = JsonConvert.DeserializeObject<List<ShoppingCartHelper>>(cartJson);
            }
        }
    }
}
