using Exercicio1.Domain.Enums;

namespace Exercicio1.Domain.Entities
{
    public class Contact : Person
    {
        public RelationshipTypeEnum RelationshipType { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}