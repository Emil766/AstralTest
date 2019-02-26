using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("ExternalVacancies")]
    public class ExternalVacanciesController
    {
        private VacanciesService vacanciesService;
        private HHParser parser;

        public ExternalVacanciesController(VacanciesService vacanciesService)
        {
            this.vacanciesService = vacanciesService;
            parser = new HHParser();
        }

        [HttpGet]
        public List<Vacancie> GetVacancies(string search)
        {
            parser.DownloadHHLinks(50);
            return parser.HHVacancies;
        }

        [HttpPost]
        public void AddVacanciesToDb()
        {
            parser.DownloadHHLinks(50);
            vacanciesService.AddVacancies(parser.HHVacancies);
        }
    }
}
