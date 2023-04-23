using eShop.DataLayer.Entities.JoinerTables;

namespace eShop.DataLayer.Entities;

public class Orders
{
    public int OrdersId { get; set; }
    public DateTime BuyDate { get; set; } = DateTime.Now;

    public ICollection<OrdersCustomer> Customers { get; set; }
    public ICollection<OrderProduct> Products { get; set; }

    public int PayOptionsId { get; set; }
    public PayOptions PayOptions { get; set; }

}
