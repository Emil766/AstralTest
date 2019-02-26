using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Vacancie
    {
        [Key]
        public string Identificator { get; set; }

        public string Url { get; set; }
        public string Headline { get; set; }
        public string Salary { get; set; }
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        public string Contacts { get; set; }
        public string EmployementType { get; set; }
        public string Description { get; set; }
    }
}
