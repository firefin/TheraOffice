using System.Globalization;

namespace ProgramAssign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            List<Physician> physicians = new List<Physician>();


            Patient p = new Patient();
            Console.WriteLine("Enter Patient Info:");
            
            Console.Write("Name: ");
            p.Name = Console.ReadLine();

            Console.Write("Age: ");
            Int32.TryParse(Console.ReadLine(), out int age);//obviously doesn't check for invalid input.
            p.Age = age;
            
            Console.Write("Address: ");
            p.Address = Console.ReadLine();

            Console.Write("Race: ");
            p.Race = Console.ReadLine();

            Console.Write("Gender: ");
            p.Gender = Console.ReadLine();

            Console.Write("Date of Birth (MM-DD-YYYY): ");
            p.Birthdate = DateTime.ParseExact(Console.ReadLine(), "MM-dd-yyyy", CultureInfo.InvariantCulture);//doesn't check for invalid input


            Console.WriteLine(p);


        }
    }





    public class Patient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Race {  get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public List<MedicalNote> MedicalNotes { get; set; } = new List<MedicalNote>();

        //Logic missing 


        //ToString overload
        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}";//missing others
        }

    }

    public class Physician
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
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
