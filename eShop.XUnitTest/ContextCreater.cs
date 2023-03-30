using eShop.DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace eShop.XUnitTest
{
    public class ContextCreater
    {
        public static eShopContext CreateContext([CallerMemberName] string dbname = "")
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(dbname);
            var context = new eShopContext(builder.Options);



            return context;

        }
    }
}
