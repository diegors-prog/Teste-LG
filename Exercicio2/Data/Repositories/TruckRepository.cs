using Exercicio2.Domain.Entities;
using Exercicio2.Domain.Interfaces.RepositoryInterfaces;

namespace Exercicio2.Data.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        public Task<IList<Truck>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Truck> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTheAmountOfTrucks()
        {
            throw new NotImplementedException();
        }

        public void Save(Truck entity)
        {
            throw new NotImplementedException();
        }
    }
}