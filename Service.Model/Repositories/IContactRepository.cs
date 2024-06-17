using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public interface IContactRepository
    {
        public Task<Contact?> GetContact(Order order);

        public Task<IEnumerable<Contact>> GetAllContacts();

        public Task Delete(Contact contact);
    }
}