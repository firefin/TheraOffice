using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AppointmentServiceProxy
    {
        private static object _lock = new object();
        public static AppointmentServiceProxy Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new AppointmentServiceProxy();
                }
                return instance;
            }
        }

        private static AppointmentServiceProxy? instance;

        private AppointmentServiceProxy()
        {
            instance = null;

            Appointments = new List<Appointment>
            {
                new Appointment{Date = DateTime.Now, Patient = new Patient{Name = "appt test patient"}, Physician = new Physician{Name = "appt test dr." }, Id = 1 },

                new Appointment{Date = DateTime.Now, Patient = new Patient{Name = "appt test patient 2"}, Physician = new Physician{Name = "appt test dr. 2" }, Id = 2 }
            };
        }

        public int LastKey
        {
            get
            {
                if (Appointments.Any())
                    return Appointments.Select(a => a.Id).Max();
                return 0;
            }
        }
        private List<Appointment> appointments;
        public List<Appointment> Appointments
        {
            get
            {
                return appointments;
            }
            private set
            {
                if (appointments != value) appointments = value;
            }
        }
        public void AddOrUpdatePatient(Appointment a)
        {
            if (a.Id <= 0)
            {
                a.Id = LastKey + 1;
                Appointments.Add(a);
            }
        }

        public void RemoveAppointment(int id)
        {
            var removePatient = Appointments.FirstOrDefault(a => a.Id == id);
            if (removePatient != null)
                Appointments.Remove(removePatient);
        }

        public void AddOrUpdate(Appointment a)
        {
            if (a.Id <= 0)
            {
                a.Id = LastKey + 1;
                Appointments.Add(a);
            }
        }
    }
}
