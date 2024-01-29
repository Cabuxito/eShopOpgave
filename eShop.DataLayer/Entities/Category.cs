﻿using eShop.DataLayer.Entities.JoinerTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryProducts> Products { get; set; }
    }
}
