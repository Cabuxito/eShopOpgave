using eShop.ServiceLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.OrderServices
{
    public interface IOrderServices
    {
        public Task CreateNewOrder(OrderProductsDTO orderDTO);
        public OrderProductsDTO GetOrderById(int id);
        public Task UpdateOrder(OrderProductsDTO orderDTO);
        public Task DeleteOrder(OrderProductsDTO orderDTO);
    }
}
