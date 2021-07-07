using System;
namespace VacancyMonolith.Models
{
    public class Vacancy
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public decimal Salary { get; set; }
        public Organization Organization { get; set; }
        public ContactPerson ContactPerson { get; set; }
        public string Phone { get; set; }
        public TypeOfEmployement TypeOfEmployment { get; set; }
        public string Description { get; set; }
    }
}
