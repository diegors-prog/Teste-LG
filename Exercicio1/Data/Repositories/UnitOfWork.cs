using Exercicio1.Data.Context;
using Exercicio1.Domain.Interfaces.RepositoryInterfaces;

namespace Exercicio1.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private ICustomerRepository _CustomerRepository;

        private IContactRepository _ContactRepository;

        public ICustomerRepository CustomerRepository
        {
            get { return _CustomerRepository ??= new CustomerRepository(_context); }
        }

        public IContactRepository ContactRepository
        {
            get { return _ContactRepository ??= new ContactRepository(_context); }
        }
    }
}