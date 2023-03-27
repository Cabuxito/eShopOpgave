using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities
{
    public class Products
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
