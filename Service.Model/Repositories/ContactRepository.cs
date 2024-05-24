using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly OrdersDbContextFactory _dbContextFactory;

        public ContactRepository(OrdersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                IEnumerable<Contact> contacts = await dbContext.Contacts.ToListAsync();

                return contacts;
            }
        }
    }
}