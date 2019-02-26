using BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class VacanciesService
    {
        private VacanciesContext vacanciesContext;

        public VacanciesService(VacanciesContext vacanciesContext)
        {
            this.vacanciesContext = vacanciesContext;
        }

        public void CreateVacancy(Vacancie vacancie)
        {
            vacanciesContext.Add(vacancie);
            vacanciesContext.SaveChanges();
        }

        public void AddVacancies(List<Vacancie> vacancies)
        {
            vacanciesContext.Vacancies.AddRange(vacancies);
            vacanciesContext.SaveChanges();
        }

        public void UpdateVacancy(Vacancie vacancie)
        {
            var vacancy = vacanciesContext.Vacancies.Find(vacancie.Identificator);

            vacancy.Description = vacancie.Description;
            //TODO остальные поля

            vacanciesContext.SaveChanges();
        }

        public void DeleteVacancy(string id)
        {
            var vacancy = vacanciesContext.Vacancies.Find(id);
            
            vacanciesContext.Vacancies.Remove(vacancy);
            vacanciesContext.SaveChanges();
        }

        public void DeleteVacancies()
        {
            var vacancies = vacanciesContext.Vacancies;
            vacanciesContext.RemoveRange(vacancies);
            vacanciesContext.SaveChanges();
        }

        public List<Vacancie> GetVacancies()
        {
            return vacanciesContext.Vacancies.ToList();
        }
    }
}
