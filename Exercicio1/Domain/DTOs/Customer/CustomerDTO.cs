namespace Exercicio1.Domain.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IList<ContactDTO> Contacts { get; set; }
    }
}