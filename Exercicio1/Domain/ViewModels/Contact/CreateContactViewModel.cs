using Exercicio1.Domain.Enums;

namespace Exercicio1.Domain.ViewModels
{
    public class CreateContactViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public RelationshipTypeEnum RelationshipType { get; set; }
        public int CustomerId { get; set; }
    }
}