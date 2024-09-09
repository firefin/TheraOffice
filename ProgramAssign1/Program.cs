using System.Globalization;


namespace ProgramAssign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            List<Physician> physicians = new List<Physician>();
            List<Appointment> appointments = new List<Appointment>();

            char input = ' ';
            while(input != 'q')
            {
                Console.WriteLine("[P] Add Patient");
                Console.WriteLine("[A] Add Appointment");
                Console.WriteLine("[D] Add Doctor");
                Console.WriteLine("Select an option: ");
                input = char.Parse(Console.ReadLine());
            }
        }
    }
}