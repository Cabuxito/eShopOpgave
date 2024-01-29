using eShop.DataLayer;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

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

        public async Task<List<CustomerDTO>> GetCustomers() => _context.Customers.Include(x => x.ZipCode).AsNoTracking().ConvertFromCustomertoDTO().ToList();

        public async Task<CustomerDTO?> GetCustomerById(int id) => _context.Customers.ConvertFromCustomertoDTO().FirstOrDefault(x => x.PrivateNumber == id);

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

        public async Task<CustomerDTO>? LoginSystem(string username, string password)
        {
            CustomerDTO? user = _context.Customers
                .Where(x => x.Email == username & x.Password == password)
                .ConvertFromCustomertoDTO().FirstOrDefault();
            return user;
        }

    }
}

