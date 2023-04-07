using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.CustomerServices
{
    public interface ICustomerServices
    {
        public Task CreateCustomerAsync(CustomerDTO customerDTO);
        public List<CustomerDTO> GetCustomers();
        public CustomerDTO? GetCustomerById(int id);
        public Task UpdateCustomerAsync(CustomerDTO customerDTO);
        public Task DeleteCustomerAsync(CustomerDTO customerDTO);
    }
}
