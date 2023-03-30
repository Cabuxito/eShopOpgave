using eShop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class ProductsDTO
    {
        public int MasterKey { get; set; } // PK
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Manufacture { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}
