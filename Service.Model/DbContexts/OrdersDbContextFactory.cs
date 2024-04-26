using Microsoft.EntityFrameworkCore;

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