using Exercicio1.Domain.Enums;

namespace Exercicio1.Domain.ViewModels
{
    public class UpdateContactViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public RelationshipTypeEnum RelationshipType { get; set; }
    }
}