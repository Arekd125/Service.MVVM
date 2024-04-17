using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services
{
    public class DatabaseOrderCreator : IOrderCreator
    {
        private readonly OrdersDbContextFactory _dbContextFactory;

        public DatabaseOrderCreator(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateOrder(Order order)
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }
        }
    }
}