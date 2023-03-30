using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; } // PK
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = "0"; // need hashes
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        
        public int ZipCodeId { get; set; } // FK

        // Navigations Property
        public ICollection<Orders> Orders { get; set; }
        public ZipCode ZipCode { get; set; }
    }
}
