namespace Exercicio1.Domain.Entities
{
    public class Customer : Person
    {
        public string Email { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}