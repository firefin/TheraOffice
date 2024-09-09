using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string id { get; private set; }
        public List<string>? Specializations { get; set; } = new List<string>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Physician() 
        {
            id = Guid.NewGuid().ToString("N").Substring(0,5);//I dont wanna type a 32-char string. Dumb? Probably.
        }

        public override string ToString()
        {
            string s = $"~~~~~~~~~~ PHYSICIAN INFO ~~~~~~~~~~" +
                $"\nName: {Name}" +
                $"\nLicense Number: {LicenseNumber}" +
                $"\nGraduation Date: {GraduationDate}" +
                $"\nSpecializations: ";

            foreach(string special in Specializations)
            {
                s += $"{special}\n";
            }
            s += $"\nAppointments: ";

            foreach(Appointment appt in Appointments)
            {
                s += $"{appt}\n";
            }
            s += "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return s;
        }

        //Logic missing
    }
}
