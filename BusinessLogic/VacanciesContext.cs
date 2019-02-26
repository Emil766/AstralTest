using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class VacanciesContext : DbContext
    {
        public VacanciesContext(DbContextOptions<VacanciesContext> options) : base(options) { }

        public DbSet<Vacancie> Vacancies { get; set; }
    }
}
