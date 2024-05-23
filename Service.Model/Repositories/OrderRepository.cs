﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<int> Create(Order order)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                Contact existingContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == order.ContactId);

                if (existingContact != null)
                {
                    existingContact.Order.Add(order);
                }
                else
                {
                    Contact newContact = new Contact { Id = order.ContactId };
                    newContact.Order.Add(order);
                    dbContext.Contacts.Add(newContact);
                }
                await dbContext.SaveChangesAsync();
                return order.Id;
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
    }
}