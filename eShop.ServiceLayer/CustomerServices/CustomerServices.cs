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

        public async Task<CustomerDTO>? LoginSystem (string username, string password)
        {
            CustomerDTO? user = _context.Customers
                .Where(x => x.Email == username & x.Password == password)
                .ConvertFromCustomertoDTO().FirstOrDefault();
            return user;
        }


        #region Shopping Cart
        

        public async Task AddItem(ProductsDTO item)
        {
            ShoppingCartDTO shoppingCart = new ShoppingCartDTO();
            var existingItem = shoppingCart.Items.FirstOrDefault(i => i.ProductId == item.MasterKey);

            if (existingItem != null)
            {
                existingItem.Stock += item.Stock;
            }
            else
            {
                shoppingCart.Items.Add(item.ConvertFromDTOtoProduct());
            }
        }

        public async Task RemoveItem(int itemId)
        {
            ShoppingCartDTO shoppingCart = new ShoppingCartDTO();
            var itemToRemove = shoppingCart.Items.FirstOrDefault(i => i.ProductId == itemId);

            if (itemToRemove != null)
            {
                shoppingCart.Items.Remove(itemToRemove);
            }
        }

        public async Task UpdateItem(int itemId, int quantity)
        {
            ShoppingCartDTO shoppingCart = new ShoppingCartDTO();
            var itemToUpdate = shoppingCart.Items.FirstOrDefault(i => i.ProductId == itemId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Stock = quantity;
            }
        }

        public double GetTotal()
        {
            ShoppingCartDTO shoppingCart = new ShoppingCartDTO();
            return shoppingCart.Items.Sum(i => i.Price * i.Stock);
        }
    }
    #endregion
}

