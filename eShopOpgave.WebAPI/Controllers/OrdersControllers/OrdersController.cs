﻿using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopOpgave.WebAPI.Controllers.OrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        /// <summary>
        /// Get a list of all orders in DB.
        /// </summary>
        /// <returns>List of orders.</returns>
        [HttpGet]
        public async Task<List<OrderDTO>> GetAllOrders()
        {
            return await _orderServices.GetAllOrders();
        }
    }
}
