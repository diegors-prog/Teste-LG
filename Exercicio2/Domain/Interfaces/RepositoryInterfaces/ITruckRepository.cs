using Exercicio2.Domain.Entities;

namespace Exercicio2.Domain.Interfaces.RepositoryInterfaces
{
    public interface ITruckRepository : IBaseRepository<Truck>
    {
         Task<int> GetTheAmountOfTrucks();
    }
}