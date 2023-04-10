using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.ModelsDTO;
using eShop.WebApp.SessionHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace eShop.WebApp.Pages.Validation
{
    public class LoginValidationModel : PageModel
    {
        private readonly ICustomerServices _customerServices;
        public LoginValidationModel(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [BindProperty, MaxLength(50), Required]
        public string Email { get; set; }

        [BindProperty, MaxLength(30), Required]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                CustomerDTO? user = await _customerServices.LoginSystem(Email.ToLower(), Password);
                if (user == null)
                {
                    return Page();
                }
                else if (user.IsAdmin == true)
                {
                    HttpContext.Session.SetSessionString(user.PrivateNumber.ToString(), "User");
                    HttpContext.Session.SetSessionString(user.Email.ToString(), "Email");
                    HttpContext.Session.SetSessionString(user.IsAdmin.ToString(), "IsAdmin");
                    return RedirectToPage("/eShopPages/Admin/AdminPage");
                }
                else if (Email.ToLower() == user.Email && Password == user.Password)
                {
                    HttpContext.Session.SetSessionString(user.PrivateNumber.ToString(), "User");
                    HttpContext.Session.SetSessionString(user.Email.ToString(), "Email");
                    return RedirectToPage("/eShopPages/Users/UserPage");
                }
            }
            return RedirectToPage("/Index");
        }
    }
}
