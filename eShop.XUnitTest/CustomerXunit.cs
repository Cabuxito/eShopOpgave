using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.OrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.XUnitTest
{
    public class CustomerXunit
    {
        [Fact]
        public async Task TestCreateCustomerAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new OrderServices(_context);
            //Arrange

            CustomerDTO customerDTO = new CustomerDTO(1, "thomas", "TheKrillz", "SkpMester@", "Alsgade");
            
            //Act

            _service.CreateCustomerAsync(customerDTO);

            //Assert
            var actualCustomer = _context.Customers.ToList().Last();

            Assert.Equal(customerDTO.Firstname, actualCustomer.Firstname);
            Assert.Equal(customerDTO.Lastname, actualCustomer.Lastname);
        }
    }
}
