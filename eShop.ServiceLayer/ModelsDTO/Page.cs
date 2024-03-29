﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class Page<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageCount => (int)Math.Ceiling(decimal.Divide(Total, PageSize));
    }
}
