using eShop.DataLayer;
using eShop.ServiceLayer.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace eShop.XUnitTest
{
    public class ContextCreater
    {
        public static eShopContext CreateContext([CallerMemberName] string dbname = "")
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(dbname);
            builder.EnableSensitiveDataLogging();
            var context = new eShopContext(builder.Options);
            return context;
        }
    }
}
