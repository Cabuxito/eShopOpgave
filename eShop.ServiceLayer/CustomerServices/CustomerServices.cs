using eShop.DataLayer;


namespace eShop.ServiceLayer.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly eShopContext _context;

        public CustomerServices(eShopContext context)
        {
            _context = context;
        }

        

        
    }
}
