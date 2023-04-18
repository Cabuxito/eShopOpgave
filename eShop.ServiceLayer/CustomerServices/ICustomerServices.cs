using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.CustomerServices
{
    public interface ICustomerServices
    {
        public Task CreateCustomerAsync(CustomerDTO customerDTO);
        public Task<List<CustomerDTO>> GetCustomers();
        public Task<CustomerDTO?> GetCustomerById(int id);
        public Task UpdateCustomerAsync(CustomerDTO customerDTO);
        public Task DeleteCustomerAsync(CustomerDTO customerDTO);
        public Task<CustomerDTO>? LoginSystem(string username, string password);

    }
}
