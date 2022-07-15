using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.ServiceInterfaces;

namespace Exercicio1.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<bool> AddCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCustomerAsync(long customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> SearchCustomerAsync(long customerId)
        {
            throw new NotImplementedException();
        }
    }
}