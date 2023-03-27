using eShop.DataLayer;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.UserServices;


namespace eShop.ServiceLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly eShopContext _eShopContext;

        public UserServices(eShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

        public async Task AddUser(CustomerDTO customer) => _eShopContext.Add(customer);


    }
}
