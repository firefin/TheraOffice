using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramAssign1
{
    public class Appointment
    {
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public Physician Physician { get; set; }

        public Appointment(DateTime date, Patient patient, Physician physician)
        {
            Date = date;
            Patient = patient;
            Physician = physician;
        }
        public void MakeAppointment(int year, int month, int day, int hour, int minute)
        {
            Date = new(year, month, day, hour, minute, 0);
        }
    }
}
