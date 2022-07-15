using Exercicio1.Domain.Interfaces;

namespace Exercicio1.Domain.Entities
{
    public abstract class Person : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}