using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities.JoinerTables
{
    public class CategoryProducts
    {
        public int CategoryId { get; set; } //FK 
        public Category Category { get; set; }
        
        public int ProductId { get; set; } //FK
        public Product Products { get; set; }
    }
}
