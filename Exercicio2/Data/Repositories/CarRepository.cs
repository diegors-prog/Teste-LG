using Exercicio2.Domain.Entities;
using Exercicio2.Domain.Interfaces.RepositoryInterfaces;

namespace Exercicio2.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        public Task<IList<Car>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Save(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}