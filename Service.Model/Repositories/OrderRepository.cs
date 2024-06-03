using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly OrdersDbContextFactory _dbContextFactory;

        public OrderRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Create(Order order)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.Orders.Add(order);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Order order)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.Orders.Remove(order);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                IEnumerable<Order> orders = await dbContext.Orders.Include(o => o.Contact).ToListAsync();

                return orders;
            }
        }

        public async Task<Order?> GetLastOrder()
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                Order? order = await dbContext.Orders
                    .Include(o => o.Contact)
                    .OrderByDescending(o => o.Id)
                    .FirstOrDefaultAsync();

                return order;
            }
        }

        public async Task<Order?> GetOrderByOrderName(string OrderName)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                var order = await dbContext.Orders.Include(o => o.Contact).FirstOrDefaultAsync(p => p.OrderName == OrderName);

                return order;
            }
        }

        public async Task<bool> AnyOrderWithContactId(int contactId)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                return await dbContext.Orders.AnyAsync(o => o.ContactId == contactId);
            }
        }
    }
}