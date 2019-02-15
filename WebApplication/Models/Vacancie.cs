using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Vacancie
    {
        public int ID { get; set; }
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
