using eShop.DataLayer.Entities.JoinerTables;

namespace eShop.DataLayer.Entities;

public class Orders
{
    public int OrdersId { get; set; }
    public DateTime BuyDate { get; set; } = DateTime.Now;

    public ICollection<Customer> Customer { get; set; }
    public ICollection<OrderProduct> Products { get; set; }

}
