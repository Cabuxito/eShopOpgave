using eShop.DataLayer;
using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace eShop.ServiceLayer.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly eShopContext _context;

        public OrderServices(eShopContext context)
        {
            _context = context;
        }

        public async Task CreateNewOrder(OrderDTO orderDTO)
        {
            _context.Orders.Add(orderDTO.ConvertFromDTOtoOrders());
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            return (OrderDTO)_context.Orders.AsNoTracking()
                .Where(x => x.OrdersId == id);
        }

        public async Task<List<OrderDTO>> GetAllOrders() => _context.Orders.AsNoTracking().ConvertOrdersTOOrdersDTO().ToList();

        public async Task UpdateOrder(OrderDTO orderDTO)
        {
            _context.Orders.Update(orderDTO.ConvertFromDTOtoOrders());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(OrderDTO orderDTO)
        {
            _context.Orders.Remove(orderDTO.ConvertFromDTOtoOrders());
            await _context.SaveChangesAsync();
        }

    }
}
