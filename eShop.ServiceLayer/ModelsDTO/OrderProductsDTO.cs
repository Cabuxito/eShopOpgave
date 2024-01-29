using eShop.DataLayer.Entities;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class OrderDTO
    {
        public int OrdersId { get; set; }
        public DateTime BuyDate { get; set; }
        public double FullPrice { get; set; }
        
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }

        public OrderDTO(int ordersId, DateTime buyDate, double fullprice, List<Product> products, Customer customer)
        {
            OrdersId = ordersId;
            BuyDate = buyDate;
            FullPrice = fullprice;
            Products = products;
            Customer = customer;
        }
    }
}
