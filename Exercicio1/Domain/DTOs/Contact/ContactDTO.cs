using Exercicio1.Domain.Enums;

namespace Exercicio1.Domain.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public RelationshipTypeEnum RelationshipType { get; set; }
    }
}