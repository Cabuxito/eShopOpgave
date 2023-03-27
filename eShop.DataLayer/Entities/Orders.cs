using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime buyDate { get; set; } = DateTime.Now;

        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
