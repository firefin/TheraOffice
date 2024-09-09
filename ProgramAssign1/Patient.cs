using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramAssign1
{
    public class Patient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string id { get; private set; }
        public List<MedicalNote> MedicalNotes { get; set; } = new List<MedicalNote>();

        //Logic missing 
        public Patient()
        {
            id = Guid.NewGuid().ToString("N").Substring(0, 5);//I dont wanna type a 32-char string. Dumb? Probably.
        }

        //ToString overload
        public override string ToString()
        {//Might need to change MedicalNotes since I doubt it'll properly print. Might need to append w/ loop
            string text = $"-*-*-*-*- PATIENT INFO -*-*-*-*-\n" +
                $"Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Birthdate: {Birthdate}\n" +
                $"Address: {Address}\n" +
                $"Race: {Race}\n" +
                $"Gender:{Gender}\n" +
                $"Medical Notes:\n";
            foreach (MedicalNote note in MedicalNotes)
            {
                text += $"\t{note}\n";
            }
            text += "-*-*-*-*--*-*-*-*--*-*-*-*--*-*-\n";//missing others
            return text;
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

