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
    public class DatabaseOrderProvider : IOrderProviders
    {
        private readonly OrdersDbContextFactory _dbContextFactory;

        public DatabaseOrderProvider(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using (OrdersDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Order> orders = await context.Orders.ToListAsync();

                return orders;
            }
        }
    }
}