using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public List<MedicalNote> MedicalNotes { get; set; } = new List<MedicalNote>();
        public Insurance? Insurance 
        { 
            get
            {
                if(insuranceId == -1)
                    return null;
               return InsuranceServiceProxy.Current.Insurances.FirstOrDefault(i => i.Id == insuranceId);
            }
            
            set
            {
                insuranceId = value?.Id ?? -1;
            }
        }
        private int insuranceId { get; set; }

        //Logic missing 
        public Patient()
        { 
            Name = string.Empty;
            Address = string.Empty;
            Race = string.Empty;
            Gender = string.Empty;
            Birthdate = DateTime.MinValue;
            Age = 0;
        }

        //ToString overload
        public override string ToString()
        {
            return Name;
        }
    }
    public class MedicalNote
    {
        public string Diagnosis { get; set; }
        public string? Prescription { get; set; }

        public MedicalNote(string diagnosis, string? prescription)
        {
            Diagnosis = diagnosis;
            Prescription = prescription;
        }

        public override string ToString()
        {
            return $"Diagnosis: {Diagnosis}\n\tPrescription: {Prescription}.";
        }
    }
}

