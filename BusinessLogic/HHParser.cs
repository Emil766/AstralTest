using BusinessLogic.Models;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication.Models
{
    public class HHParser
    {
        private readonly string Url = "https://kaluga.hh.ru/search/vacancy?area=43&clusters=true&enable_snippets=true&specialization=1&page=";
        public List<Vacancie> HHVacancies { get; set; }


        public HHParser()
        {
            HHVacancies = new List<Vacancie>();
        }

        #region methods

        public void DownloadHHLinks(int Count)
        {
            HtmlDocument HtmlDoc = new HtmlDocument();
            HtmlWeb Web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            int i = 0;
            try
            {
                while (HHVacancies.Count < Count)
                {
                    HtmlDoc = Web.Load(Url + i);
                    var htmlNodes = HtmlDoc.DocumentNode.SelectSingleNode("//div[@class = 'vacancy-serp']").ChildNodes.Where(a => a.GetAttributeValue("class", "none").Contains("vacancy-serp-item"));
                    if (htmlNodes != null)
                    {
                        foreach (var node in htmlNodes)
                        {
                            HHVacancies.Add(new Vacancie()
                            {
                                Url = node.SelectSingleNode(".//a[@class = 'bloko-link HH-LinkModifier']").GetAttributeValue("href", "none"),
                                Headline = node.SelectSingleNode(".//a[@class = 'bloko-link HH-LinkModifier']").InnerText,
                                Organization = node.SelectSingleNode(".//a[@data-qa = 'vacancy-serp__vacancy-employer']").InnerText,
                                Description = node.SelectSingleNode(".//div[@data-qa = 'vacancy-serp__vacancy_snippet_responsibility']").InnerText
                                              + node.SelectSingleNode(".//div[@data-qa = 'vacancy-serp__vacancy_snippet_requirement']").InnerText
                            });
                            if (HHVacancies.Count > Count - 1) { break; }
                        }
                    }
                    i++;
                }
            }
            catch { return; }
            HtmlDocument InnerHtmlDoc = new HtmlDocument();
            foreach (var vacancie in HHVacancies)
            {
                HtmlDoc = Web.Load(vacancie.Url);
                try { vacancie.Salary = HtmlDoc.DocumentNode.SelectSingleNode("//p[@class = 'vacancy-salary']").InnerText; }
                catch { }
                try
                {
                    vacancie.EmployementType = HtmlDoc.DocumentNode.SelectSingleNode("//meta[@itemprop = 'employmentType']").InnerText
                                       + HtmlDoc.DocumentNode.SelectSingleNode("//span[@itemprop = 'workHours']").InnerText;
                }
                catch { }
                try { vacancie.ContactPerson = HtmlDoc.DocumentNode.SelectSingleNode("//p[@data-qa = 'vacancy-contacts__fio']").InnerText; }
                catch { }
                try
                {
                    vacancie.Contacts = HtmlDoc.DocumentNode.SelectSingleNode("//p[@data-qa = 'vacancy-contacts__phone']").InnerText
                                  + " " + HtmlDoc.DocumentNode.SelectSingleNode("//a[@data-qa = 'vacancy-contacts__email']").InnerText;
                }
                catch { }
            }
        }


        #endregion
    }
}
