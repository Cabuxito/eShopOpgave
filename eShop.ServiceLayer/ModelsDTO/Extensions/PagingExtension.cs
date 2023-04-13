using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ServiceLayer.ModelsDTO.Extensions
{
    public static class PagingExtension
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int start, int take) => query.Skip((start - 1) * take).Take(take);
    }
}
