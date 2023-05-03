using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopOpgave.WebAPI.Controllers.OrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        /// <summary>
        /// Create new Order. ( Under Development )  
        /// </summary>
        /// <param name="orderDTO"></param>
        /// /// <remarks>
        /// Sample request:
        ///
        ///
        /// </remarks>
        [HttpPost]
        public async Task CreateNewOrder(OrderDTO orderDTO)
        {
            await _orderServices.CreateNewOrder(orderDTO);
        }
    }
}
