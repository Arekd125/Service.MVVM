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
                IEnumerable<Order> orders = await dbContext.Orders.Include(o => o.Contact).Include(t => t.ToDo).ToListAsync();

                return orders;
            }
        }

        public async Task<Order?> GetLastOrder()
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                Order? order = await dbContext.Orders
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

        public async Task UpDate(Order order)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                var orderToUpdate = await GetOrderByOrderName(order.OrderName);

                orderToUpdate.Contact = order.Contact;
                orderToUpdate.ContactId = order.ContactId;
                orderToUpdate.Device = order.Device;
                orderToUpdate.Model = order.Model;
                orderToUpdate.Description = order.Description;
                orderToUpdate.ToDo = order.ToDo;
                orderToUpdate.Accessories = order.Accessories;
                orderToUpdate.Cost = order.Cost;
                dbContext.Orders.Update(orderToUpdate);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpDateStatus(string orderName)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                var orderToUpdate = await GetOrderByOrderName(orderName);

                orderToUpdate.IsFinished = !orderToUpdate.IsFinished;

                dbContext.Orders.Update(orderToUpdate);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                IEnumerable<Order> orders = await dbContext.Orders
                    .Include(o => o.Contact)
                    .Include(t => t.ToDo)
                    .Where(o => o.StartDate.Date <= startDate.Date && o.StartDate.Date >= endDate.Date).ToListAsync();

                return orders;
            }
        }
    }
}