﻿using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services
{
    public class DatabaseOrderCreator : DatabaseServiceBase, IOrderCreator
    {
        public DatabaseOrderCreator(OrdersDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
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