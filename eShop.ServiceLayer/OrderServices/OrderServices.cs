using eShop.DataLayer;
using eShop.DataLayer.Entities;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly eShopContext _context;

        public OrderServices(eShopContext context)
        {
            _context = context;
        }

        public async Task CreateNewOrder(OrderProductsDTO orderDTO)
        {
            _context.Orders.Add(orderDTO.ConvertFromDTOtoOrders());
            await _context.SaveChangesAsync();
        }

        public OrderProductsDTO GetOrderById(int id)
        {
            return (OrderProductsDTO)_context.Orders
                .Where(x => x.OrdersId == id);
        }

        public List<OrderProductsDTO> GetAllOrders() => _context.Orders.ConvertOrdersTOOrdersDTO().ToList();

        public async Task UpdateOrder(OrderProductsDTO orderDTO)
        {
            _context.Orders.Update(orderDTO.ConvertFromDTOtoOrders());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(OrderProductsDTO orderDTO)
        {
            _context.Orders.Remove(orderDTO.ConvertFromDTOtoOrders());
            await _context.SaveChangesAsync();
        }

    }
}
