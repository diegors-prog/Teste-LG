namespace Exercicio1.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

         ICustomerRepository CustomerRepository {get;}
         IContactRepository ContactRepository {get;}
    }
}