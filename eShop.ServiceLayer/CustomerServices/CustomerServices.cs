using eShop.DataLayer;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly eShopContext _context;

        public CustomerServices(eShopContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAsync(CustomerDTO customerDTO)
        {
            _context.Customers.Add(customerDTO.ConvertFromDTOtoCustomer());
            await _context.SaveChangesAsync();
        }

        public List<CustomerDTO> GetCustomers() => _context.Customers.Cast<CustomerDTO>().ToList();

        public CustomerDTO? GetCustomerById(int id) => _context.Customers.ConvertFromCustomertoDTO().FirstOrDefault(x => x.PrivateNumber == id);

        public async Task UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            _context.Customers.Update(customerDTO.ConvertFromDTOtoCustomer());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(CustomerDTO customerDTO)
        {
            _context.Customers.Remove(customerDTO.ConvertFromDTOtoCustomer());
            await _context.SaveChangesAsync();
        }


    }
}
