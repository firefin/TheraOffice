namespace ProgramAssign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }





    public class Patient
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Race {  get; set; }
        public required string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public List<MedicalNote> MedicalNotes { get; set; } = new List<MedicalNote>();
                                                          
        //Logic missing 
        
    }

    public class Physician
    {
        public required string Name { get; set; }
        public required string LicenseNumber { get; set; }
        public DateTime GraduationDate { get; set; }
        public List<string>? Specializations { get; set; }

        public List<Appointment> Appointments { get; set; }

        //Logic missing
    }

    public class MedicalNote 
    { 
        public required string Diagnosis { get; set; }
        public string? Prescription { get; set; }

        public MedicalNote(string diagnosis, string? prescription)
        {
            Diagnosis = diagnosis;
            Prescription = prescription;
        }
    }

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
    }
}
