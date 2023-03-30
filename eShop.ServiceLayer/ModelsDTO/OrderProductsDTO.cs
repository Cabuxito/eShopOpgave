using eShop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class OrderProductsDTO
    {
        public int OrdersId { get; set; }
        public DateTime BuyDate { get; set; }
        public double FullPrice { get; set; }

        public List<Product> Products { get; set; }

        public OrderProductsDTO(int ordersId, DateTime buyDate, double fullprice, List<Product> products)
        {
            OrdersId = ordersId;
            BuyDate = buyDate;
            FullPrice = fullprice;
            Products = products;
        }
    }
}
