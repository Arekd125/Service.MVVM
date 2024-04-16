using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.DbContexts
{
    public class OrdersDbContextFactory
    {
        private readonly string _connectionString;

        public OrdersDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OrdersDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new OrdersDbContext(options);
        }
    }
}