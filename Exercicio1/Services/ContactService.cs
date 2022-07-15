using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.ServiceInterfaces;

namespace Exercicio1.Services
{
    public class ContactService : IContactService
    {
        public Task<bool> AddContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Contact>> GetAllContactsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveContactAsync(long contactId)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> SearchContactAsync(long contactId)
        {
            throw new NotImplementedException();
        }
    }
}