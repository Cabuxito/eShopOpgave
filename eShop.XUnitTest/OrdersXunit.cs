
using eShop.DataLayer.Entities;
using eShop.ServiceLayer.Services;
using eShop.ServiceLayer.OrderServices;

namespace eShop.XUnitTest;

public class OrdersXunit
{
    [Fact]
    public async Task TestCreateOrder()
    {
        var _context = ContextCreater.CreateContext();
        var _service = new OrderServices(_context);

        //Arrange
        OrderProductsDTO orderProductsDTO = new
        (
            1,
            DateTime.UtcNow,
            2000,
            _context.Products.Take(1).ToList()
        );
        //Act

        await _service.CreateNewOrder( orderProductsDTO );

        //Assert
        var actualOrder = _context.Orders.ToList().Last();

        Assert.Equal(orderProductsDTO.BuyDate, actualOrder.BuyDate);
        Assert.Equal(orderProductsDTO.OrdersId, actualOrder.OrdersId);
    }

    [Fact]
    public void TestGetOrders()
    {
        var _context = ContextCreater.CreateContext();
        var _service = new ServiceLayer.OrderServices.OrderServices(_context);
        //Arrange
        _context.Orders.Add(new Orders
        {
            OrdersId = 1,
            BuyDate = DateTime.UtcNow,
            Customer = _context.Customers.ToList()
        });
        _context.SaveChanges();
        //Act

        var list = _service.GetAllOrders().Count();

        //Assert

        Assert.Equal(list, 1);

    }
}
