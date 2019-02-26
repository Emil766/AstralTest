using System.Collections.Generic;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("/Vacancies")]
    public class VacanciesController : Controller
    {
        private VacanciesService _vacanciesService;

        public VacanciesController(VacanciesService vacanciesService)
        {
            _vacanciesService = vacanciesService;
        }

        [HttpGet]
        public List<Vacancie> GetVacancies()
        {
            return _vacanciesService.GetVacancies();
        }

        [HttpPost]
        public void CreateVacancie(Vacancie vacancie)
        {
            _vacanciesService.CreateVacancy(vacancie);
        }

        [HttpPut]
        public void UpdateVacacie(Vacancie vacancie)
        {
            _vacanciesService.UpdateVacancy(vacancie);
        }

        [HttpDelete]
        public void DeleteVacancie(string id)
        {
            _vacanciesService.DeleteVacancy(id);
        }

        [HttpDelete("all")]
        public void DeleteAll()
        {
            _vacanciesService.DeleteVacancies();
        }
    }
}