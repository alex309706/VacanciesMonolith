using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace VacancyMonolith.Models.Realisations
{
    public class VacancyContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public VacancyContext(DbContextOptions<VacancyContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            DBInitializer.Initialize(this);
        }
        public DbSet<Organization> Organizations{ get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
