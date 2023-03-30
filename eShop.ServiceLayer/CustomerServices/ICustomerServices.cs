using eShop.ServiceLayer.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.CustomerServices
{
    public interface ICustomerServices
    {
        public Task CreateCustomerAsync(CustomerDTO customerDTO);
        public List<CustomerDTO> GetCustomers();
        public Task UpdateCustomerAsync(CustomerDTO customerDTO);
        public Task DeleteCustomerAsync(CustomerDTO customerDTO);
    }
}
