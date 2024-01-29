using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities
{
    public class ZipCode
    {
        public int ZipCodeId { get; set; } // PK
        public string ZipCodeName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
