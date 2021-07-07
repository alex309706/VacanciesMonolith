using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VacancyMonolith.Models.Interfaces;

namespace VacancyMonolith.Models.Realisations
{
    public class VacancyRepository : IVacancyRepository
    {
        private VacancyContext db;
        public VacancyRepository(DbContextOptions<VacancyContext> options)
        {
            db = new VacancyContext(options);
        }
        public void Create(Vacancy newItem)
        {
            db.Vacancies.Add(newItem);
        }

        public void Delete(Guid guidOfItemToDelete)
        {
            Vacancy vacancyToDelete = db.Vacancies.FirstOrDefault(vacancy => vacancy.Id == guidOfItemToDelete);
            if (vacancyToDelete != null)
            {
                db.Vacancies.Remove(vacancyToDelete);
            }
        }

        public IEnumerable<Vacancy> GetAll()
        {
            return db.Vacancies.ToList();
        }

        public Vacancy Get(Guid guidOfEntity)
        {

            return db.Vacancies.FirstOrDefault(vacancy => vacancy.Id == guidOfEntity);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Vacancy itemToUpdate)
        {
            db.Entry(itemToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
