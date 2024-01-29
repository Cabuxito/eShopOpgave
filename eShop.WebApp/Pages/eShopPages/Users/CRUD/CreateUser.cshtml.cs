using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace eShop.WebApp.Pages.eShopPages.Users.CRUD
{
    public class CreateUserModel : PageModel
    {
        private readonly ICustomerServices _customerServices;

        public CreateUserModel(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [BindProperty, MaxLength(50)]
        public string FirstName { get; set; }
        [BindProperty, MaxLength(50)]
        public string LastName { get; set; }
        [BindProperty, MaxLength(50), Required]
        public string Email { get; set; }
        [BindProperty, MaxLength(50), Required]
        public string Password { get; set; }
        [BindProperty, MaxLength(50), Required]
        public string PasswordValidation { get; set; }
        [BindProperty, MaxLength(50)]
        public string Address { get; set; }
        [BindProperty]
        public int ZipCode { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                CustomerDTO newCustomer = new CustomerDTO(FirstName, LastName, Email,Password,Address,ZipCode);
                if (newCustomer != null)
                {
                    await _customerServices.CreateCustomerAsync(newCustomer);
                    return RedirectToPage("/eShopPages/Users/UserPage");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
