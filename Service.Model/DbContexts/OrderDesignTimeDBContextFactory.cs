using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.DbContexts
{
    public class OrderDesignTimeDBContextFactory : IDesignTimeDbContextFactory<OrdersDbContext>
    {
        public OrdersDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=serviceDB.db").Options;

            return new OrdersDbContext(options);
        }
    }
}