using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class CustomerDTO
    {
        public int PrivateNumber { get; set; } // PK
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public CustomerDTO(string fname, string lname, string email, string adress)
        {
            Firstname = fname;
            Lastname = lname;
            Email = email;
            Address = adress;
        }
            
    }
}
