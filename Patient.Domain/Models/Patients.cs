using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Domain.Models
{
    public class Patients
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StudyDescription { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public string? Gender { get; set; }
        public string? PerPhysician { get; set; }
        public string? RefPhysician { get; set; }
    }
}
