using Exercicio1.Data.Context;
using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int entityId)
        {
            var contact = _context.DbSetContact.FirstOrDefault(x => x.Id == entityId);

            if (contact == null)
                return false;
            else
            {
                _context.DbSetContact.Remove(contact);
                return true;
            }
        }

        public async Task<IList<Contact>> GetAllAsync()
        {
            return await _context.DbSetContact.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int entityId)
        {
            return await _context.DbSetContact
            .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Contact entity)
        {
            _context.DbSetContact.Add(entity);
        }

        public void Update(Contact entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}