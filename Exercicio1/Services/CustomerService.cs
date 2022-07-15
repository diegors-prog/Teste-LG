using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.RepositoryInterfaces;
using Exercicio1.Domain.Interfaces.ServiceInterfaces;

namespace Exercicio1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _customerRepository.Save(customer);
            await _unitOfWork.CommitAsync();
            return customer;
        }

        public async Task EditCustomerAsync(Customer customer)
        {
            _customerRepository.Update(customer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<bool> RemoveCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            
            // o banco já faz essa validação, pelo OnDelete.Retrict.
            // A regra implementada aqui é que um cliente só pode ser removido
            // da base de dados se não existir nenhum contato vinculado.
            // Mas essa validação funcionaria tbm, pq no repositorio
            // estou fazendo um Include e trazendo a lista de contatos junto.
            if (customer.Contacts.Count != 0)
                return false;
            else
            {
                var removed = _customerRepository.Delete(customerId);
                await _unitOfWork.CommitAsync();

                return removed;
            }
        }

        public async Task<Customer> SearchCustomerAsync(int customerId)
        {
            return await _customerRepository.GetByIdAsync(customerId);
        }
    }
}