using Exercicio1.Data.Context;
using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int entityId)
        {
            var customer = _context.DbSetCustomer.FirstOrDefault(x => x.Id == entityId);

            if (customer == null)
                return false;
            else
            {
                _context.DbSetCustomer.Remove(customer);
                return true;
            }
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _context.DbSetCustomer
            .AsNoTracking()
            .Include(x => x.Contacts)
            .ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int entityId)
        {
            return await _context.DbSetCustomer
            .AsNoTracking()
            .Include(x => x.Contacts)
            .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Customer entity)
        {
            _context.DbSetCustomer.Add(entity);
        }

        public void Update(Customer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}