using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services
{
    public class DatabaseOrderProvider : DatabaseServiceBase, IOrderProviders
    {
        public DatabaseOrderProvider(OrdersDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Order> orders = await context.Orders.Include(o => o.Contact).ToListAsync();

                return orders;
            }
        }
    }
}