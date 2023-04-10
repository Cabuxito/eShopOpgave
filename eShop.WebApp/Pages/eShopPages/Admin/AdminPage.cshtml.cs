using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.OrderServices;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.WebApp.Pages.Admin
{
    public class AdminPageModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly ICustomerServices _customerServices;
        private readonly IOrderServices _orderServices;

        public AdminPageModel(IProductServices productServices, ICustomerServices customerServices, IOrderServices orderServices)
        {
            _productServices = productServices;
            _customerServices = customerServices;
            _orderServices = orderServices;
        }

        public List<ProductsDTO> Products { get; set; }
        public List<CustomerDTO> Customer { get; set; }
        public List<OrderDTO> Order { get; set; }

        public void OnGet()
        {
        }
    }
}
