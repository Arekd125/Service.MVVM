using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public interface IContactRepository
    {
        public Task<Contact> GetContact(Order order);

        public Task<IEnumerable<Contact>> GetAllContacts();
    }
}