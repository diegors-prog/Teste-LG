using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.RepositoryInterfaces;
using Exercicio1.Domain.Interfaces.ServiceInterfaces;

namespace Exercicio1.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(
            IContactRepository contactRepository,
            IUnitOfWork unitOfWork)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            IList<Contact> duplicateContacts = new List<Contact>();

            var contactList = await _contactRepository.GetAllAsync();
            
            if (contactList.Count != 0)
            {
                foreach(var contactInList in contactList)
                {
                    if ((contactInList.Id == contact.Id && contactInList.PhoneNumber == contact.PhoneNumber) || 
                        (contactInList.Id == contact.Id && contactInList.RelationshipType == contact.RelationshipType))
                        duplicateContacts.Add(contactInList);
                }
            }

            if (duplicateContacts.Count != 0)
                return false;
            else
            {
                _contactRepository.Save(contact);
                await _unitOfWork.CommitAsync();
                return true;
            }
        }

        public async Task EditContactAsync(Contact contact)
        {
            _contactRepository.Update(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IList<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<bool> RemoveContactAsync(int contactId)
        {
            var removed = _contactRepository.Delete(contactId);
            if (removed)
                await _unitOfWork.CommitAsync();

            return removed;
        }

        public async Task<Contact> SearchContactAsync(int contactId)
        {
            return await _contactRepository.GetByIdAsync(contactId);
        }
    }
}