using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void Onget()
        {
            ShoppingCartDTO cartDTO = new ShoppingCartDTO();
            if (HttpContext.Session.TryGetValue("ShoppingCart", out byte[] value))
            {
                cartDTO.Items = JsonSerializer.Deserialize<List<Product>>(value);
            }
            else
            {
                HttpContext.Session.Set("ShoppingCart", JsonSerializer.SerializeToUtf8Bytes(cartDTO.Items));
            }
        }

        public IActionResult AddToCart(int id, int quantity)
        {
            ProductsDTO product = _productServices.GetProductById(id);

            if (product != null)
            {
                _customerServices.AddItem(new ProductsDTO
                {
                    MasterKey = product.MasterKey,
                    Title = product.Title,
                    Price = product.Price,
                    Stock = quantity
                });
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            _customerServices.RemoveItem(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            _customerServices.UpdateItem(id, quantity);

            return RedirectToAction(nameof(Index));
        }
    }
}
