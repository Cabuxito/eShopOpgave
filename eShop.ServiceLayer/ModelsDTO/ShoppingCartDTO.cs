using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class ShoppingCartDTO
    {
        public List<Product> Items { get; set; } = new List<Product>();
    }
}
