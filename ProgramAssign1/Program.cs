using System.Globalization;

namespace ProgramAssign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            List<Physician> physicians = new List<Physician>();


            // TODO: Implement a menu to add physician, patient, add appointment to physician, and view (& edit?) patient
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

            Console.Write("Date of Birth (MM-dd-yyyy): ");
            p.Birthdate = DateTime.ParseExact(Console.ReadLine(), "MM-dd-yyyy", CultureInfo.InvariantCulture);//doesn't check for invalid input

            MedicalNote note = new MedicalNote("Sample diagnosis", "Sample prescription");
            p.AddNote(note);

            MedicalNote note2 = new MedicalNote("2nd sample diagnosis", "None");
            p.AddNote(note2);

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
        {//Might need to change MedicalNotes since I doubt it'll properly print. Might need to append w/ loop
            string text = $"-*-*-*-*- PATIENT INFO -*-*-*-*-\n" +
                $"Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Birthdate: {Birthdate}\n" +
                $"Address: {Address}\n" +
                $"Race: {Race}\n" +
                $"Gender:{Gender}\n" +
                $"Medical Notes:\n";
                foreach( MedicalNote note in MedicalNotes)
                {
                text += $"\t{note.ToString()}\n";
                }
                text+="-*-*-*-*--*-*-*-*--*-*-*-*--*-*-";//missing others
            return text;
        }

        public void AddNote(MedicalNote note)
        {
            MedicalNotes.Add(note);
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
