using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Services
{
    public class PatientServiceProxy
    {
        private static object _lock = new object();
        public static PatientServiceProxy Current
        {
            get
            {
                lock(_lock)
                {
                    if(instance == null)
                        instance = new PatientServiceProxy();
                }
                return instance;
            }
        }

        private static PatientServiceProxy? instance;

        private PatientServiceProxy() 
        {
            instance = null;

            Patients = new List<Patient>
            {
                new Patient{Name = "Test Patient", Id = 1},
                new Patient{Name = "Other Test Patient", Id = 2}
            };
        }

        public int LastKey
        {
            get
            {
                if (Patients.Any())
                    return Patients.Select(x => x.Id).Max();
                return 0;
            }
        }
        private List<Patient> patients;
        public List<Patient> Patients
        { 
            get 
            { 
                return patients; 
            }
            private set
            {
                if(patients != value) patients = value;
            }
        }
        public void AddOrUpdatePatient(Patient p)
        {
            if (p.Id <= 0)
            {
                p.Id = LastKey + 1;
                Patients.Add(p);
            }
        }

        public void RemovePatient(int id) 
        {
            var removePatient = Patients.FirstOrDefault(p => p.Id == id);
            if(removePatient != null)
                Patients.Remove(removePatient);
        }
    }
}
