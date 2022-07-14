namespace Exercicio2.Domain.Interfaces.RepositoryInterfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
         Task<Entity> GetByIdAsync(int entityId);
         Task<IList<Entity>> GetAllAsync();
         void Save(Entity entity);
    }
}