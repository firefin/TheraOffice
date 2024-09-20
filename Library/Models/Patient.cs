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
            return $"[ {Id} ] {Name}";
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

