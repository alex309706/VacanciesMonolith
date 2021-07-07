using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacancyMonolith.Models;
using VacancyMonolith.Models.Realisations;

namespace VacancyMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly VacancyContext _context;

        public VacanciesController(VacancyContext context)
        {
            _context = context;
        }

        // GET: api/Vacancies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacancy>>> GetVacancies()
        {
            return await _context.Vacancies.ToListAsync();
        }

        //поиск по Guid ...Пока не знаю как их различить

        //// GET: api/Vacancies/SomeGuid
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Vacancy>> GetVacancy(Guid id)
        //{
        //    var vacancy = await _context.Vacancies.FindAsync(id);

        //    if (vacancy == null)
        //    {
        //        return NotFound();
        //    }
        //    return vacancy;
        //}

        // GET: api/Vacancies/Astral
        [HttpGet("{organizaionName}")]
        public async Task<ActionResult<IEnumerable<Vacancy>>> GetVacanciesByOrganisation(string organizaionName)
        {
            var vacanciesFromOrganization =  await Task.Run(()=>
            _context.Vacancies.Where(vacancy => vacancy.Organization.Name == organizaionName));

            if (vacanciesFromOrganization == null)
            {
                return NotFound();
            }
            return vacanciesFromOrganization.ToList();
        }
        // PUT: api/Vacancies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacancy(Guid id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacancyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vacancies
        [HttpPost]
        public async Task<ActionResult<Vacancy>> PostVacancy(Vacancy vacancy)
        {
            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacancy", new { id = vacancy.Id }, vacancy);
        }

        // DELETE: api/Vacancies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(Guid id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacancyExists(Guid id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
