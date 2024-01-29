
using Microsoft.EntityFrameworkCore;

namespace eShop.DataLayer.Entities.JoinerTables;

public class OrderProduct
{
    public int OrdersId { get; set; }  //FK >
    public Orders Orders { get; set; }

    public int ProductId { get; set; } //FK >
    public Product Products { get; set; }

    public int Amount { get; set; }
}
