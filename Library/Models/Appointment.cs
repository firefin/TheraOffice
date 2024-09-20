using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Appointment
    {
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }


        public Appointment(DateTime date, Patient patient)
        {
            Date = date;
            Patient = patient;
        }
        public void MakeAppointment(int year, int month, int day, int hour, int minute)
        {
            Date = new(year, month, day, hour, minute, 0);
        }
        public override string ToString() 
        {
            return $"Patient: {Patient.Name} ({Patient.Id}) | Date: {Date}"; 
        }
    }
}
