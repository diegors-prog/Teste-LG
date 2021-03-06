using Exercicio1.Domain.Entities;

namespace Exercicio1.Domain.Interfaces.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task<Customer> SearchCustomerAsync(int customerId);
        Task EditCustomerAsync(Customer customer);
        Task<bool> RemoveCustomerAsync(int customerId);
    }
}