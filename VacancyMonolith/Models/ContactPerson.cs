using System;
namespace VacancyMonolith.Models
{
    public class ContactPerson
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
