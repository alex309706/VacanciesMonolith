using System;

namespace VacancyMonolith.Models
{
    public class Organization
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        //список вакансий может тут нужен?
    }
}
