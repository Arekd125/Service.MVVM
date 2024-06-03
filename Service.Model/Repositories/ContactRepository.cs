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

        public async Task<Contact?> GetContact(Order order)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                return await dbContext.Contacts.FirstOrDefaultAsync(x => x.Name == order.Contact.Name && x.PhoneNumber == order.Contact.PhoneNumber);
            }
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                IEnumerable<Contact> contacts = await dbContext.Contacts.ToListAsync();

                return contacts;
            }
        }

        public async Task Delete(Contact contact)
        {
            using OrdersDbContext dbContext = _dbContextFactory.CreateDbContext();
            {
                dbContext.Contacts.Remove(contact);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}