using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramAssign1
{
    public class Physician
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime GraduationDate { get; set; }
        public Guid id { get; private set; }
        public List<string>? Specializations { get; set; }
        public List<Appointment> Appointments { get; set; }

        //Logic missing
    }
}
