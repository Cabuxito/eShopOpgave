
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

        [BindProperty(SupportsGet = true)]
        public string AdminChoice { get; set; }

        public Page<ProductsDTO> Products { get; set; }
        public List<CustomerDTO> Customer { get; set; }
        public List<OrderDTO> Order { get; set; }

        [BindProperty(SupportsGet = true)]
        public int productID { get; set; }
        public bool ProductCheck { get; set; }
        public bool CustomerCheck { get; set; }
        public bool OrderCheck { get; set; }

        public async Task OnGetAsync()
        {
            switch (AdminChoice)
            {
                case "Products":
                    ProductCheck = true;
                    Products = await _productServices.GetAllProducts( 1, 100);
                    break;
                case "Customers":
                    CustomerCheck = true;
                    Customer = await _customerServices.GetCustomers();
                    break;
                case "Order":
                    OrderCheck = true;
                    Order = await _orderServices.GetAllOrders();
                    break;
                default:
                    break;
            }
        }

        public async Task<IActionResult> OnPostAsync(int productID)
        {
            await _productServices.DeleteProductAsync(productID);
            return Page();
        }
    }
}
