using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities.JoinerTables
{
    public class OrderCustomer
    {
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }

        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
