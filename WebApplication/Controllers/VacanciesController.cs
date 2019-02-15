using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly DbContextOptions<VacanciesContext> dbContextOptions = new DbContextOptionsBuilder<VacanciesContext>().UseSqlServer("Data Source=Emil;Initial Catalog=VacanciesContext;Integrated Security=True").Options;
        VacanciesContext db;
        HHParser parser;
        List<Vacancie> vacancies;

        public IActionResult Vacancies()
        {
            parser = new HHParser();
            parser.DownloadHHLinks(50);
            if (parser.HHVacancies.Count != 0)
            {
                vacancies = parser.HHVacancies;
                using (db = new VacanciesContext(dbContextOptions))
                {
                    db.Vacancies.RemoveRange(db.Vacancies);
                    db.Vacancies.AddRange(parser.HHVacancies);
                    db.SaveChanges();
                }
            }
            else
            {
                using (db = new VacanciesContext(dbContextOptions))
                {
                    vacancies = db.Vacancies.ToList();
                }
            }
            return View("Vacancies", vacancies);
        }
    }
}