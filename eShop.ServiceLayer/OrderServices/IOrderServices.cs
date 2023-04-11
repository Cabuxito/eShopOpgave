using eShop.ServiceLayer.ModelsDTO;

namespace eShop.ServiceLayer.OrderServices
{
    public interface IOrderServices
    {
        public Task CreateNewOrder(OrderDTO orderDTO);
        public Task<OrderDTO> GetOrderById(int id);
        public Task<List<OrderDTO>> GetAllOrders();
        public Task UpdateOrder(OrderDTO orderDTO);
        public Task DeleteOrder(OrderDTO orderDTO);
    }
}
