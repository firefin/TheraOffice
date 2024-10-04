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

        public string PatientName { get => Patient.Name; }
        public string PhysicianName { get => Physician.Name; }
        

        public Appointment() { }
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
            return Date.ToString();
        }
    }
}
