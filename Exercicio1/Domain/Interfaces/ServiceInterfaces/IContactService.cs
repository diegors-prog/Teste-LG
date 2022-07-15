using Exercicio1.Domain.Entities;

namespace Exercicio1.Domain.Interfaces.ServiceInterfaces
{
    public interface IContactService
    {
        Task<bool> AddContactAsync(Contact contact);
        Task<IList<Contact>> GetAllContactsAsync();
        Task<Contact> SearchContactAsync(int contactId);
        Task EditContactAsync(Contact contact);
        Task<bool> RemoveContactAsync(int contactId);
    }
}