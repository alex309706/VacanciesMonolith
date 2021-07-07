using System;
using System.Collections.Generic;
namespace VacancyMonolith.Models.Interfaces
{
    public interface IVacancyRepository
    {
        IEnumerable<Vacancy> GetAll();
        Vacancy Get(Guid guidOfVacancy);
        void Create(Vacancy newVacancy);
        void Update(Vacancy VacancyToUpdate);
        void Delete(Guid guidOfVacancyToDelete);
        void Save();
    }
}
