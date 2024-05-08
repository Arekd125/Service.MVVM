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
        public Task<int> Create(Contact contact);

        public Task<IEnumerable<Contact>> GetAllContacts();
    }
}