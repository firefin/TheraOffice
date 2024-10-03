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
        public Physician Physician { get; set; } //might need to remove/refactor this depending on how implementing appointments needs to be done.
        public int Id { get; set; }
  
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
        public override string ToString() 
        {
            return Display;
        }

        private string Display
        {
            get => Date.ToString(); //for now, just returns the date as a string object.
        }
    }
}
