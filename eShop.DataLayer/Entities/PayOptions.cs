using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities
{
    public class PayOptions
    {
        public int PayOptionsId { get; set; }
        public string PayOptionsName { get; set; }
        
        public ICollection<Orders> Orders { get; set; }
    }
}
