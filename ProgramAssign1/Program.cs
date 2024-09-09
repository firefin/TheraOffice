using System.Globalization;


namespace ProgramAssign1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            List<Physician> physicians = new List<Physician>();
            List<Appointment> appointments = new List<Appointment>();

            char input = ' ';
            while(input != 'q')
            {
                Console.WriteLine("####### MENU #######");
                Console.WriteLine("[P] Add Patient");
                Console.WriteLine("[A] Add Appointment");
                Console.WriteLine("[D] Add Doctor");
                Console.WriteLine("[L] List Items");
                Console.WriteLine("[Q] Quit Program");
                Console.WriteLine("#####################");
                Console.WriteLine("Select an option: ");
                input = Char.ToLower(char.Parse(Console.ReadLine()));//reads line, parses to char, then lowercases it.
                
                switch (input)
                {
                    case 'p'://add a patient
                        Patient tempPatient = new Patient();

                        bool ageValidation = false;
                        bool patientValidation = false;

                        do
                        {
                            Console.WriteLine("Patient name: ");
                            tempPatient.Name = Console.ReadLine();

                            Console.WriteLine("Patient address: ");
                            tempPatient.Address = Console.ReadLine();

                            Console.WriteLine("Patient race: ");
                            tempPatient.Race = Console.ReadLine();

                            Console.WriteLine("Patient gender:");
                            tempPatient.Gender = Console.ReadLine();


                            do
                            {
                                Console.WriteLine("Patient birthdate (MM-dd-yyyy): ");
                                tempPatient.Birthdate = DateTime.ParseExact(Console.ReadLine(), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                                tempPatient.Age = DateTime.Today.Year - tempPatient.Birthdate.Year - (DateTime.Today < tempPatient.Birthdate.AddYears(DateTime.Today.Year - tempPatient.Birthdate.Year) ? 1 : 0);
                                Console.WriteLine($"Patient calculated as {tempPatient.Age} year{(tempPatient.Age == 1 ? "" : "s")} old. Correct? (y/n)");
                                if (Console.ReadLine().ToLower() == "y")
                                    ageValidation = true;
                            }
                            while (!ageValidation);
                            Console.WriteLine($"{tempPatient}Is all the information above correct? (y/n)");
                            if (Console.ReadLine().ToLower() == "y")
                                patientValidation = true;
                        }
                        while (!patientValidation);

                        patients.Add(tempPatient);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Patient added successfully!");
                        Console.ResetColor();
                        break;



                    case 'a'://Add an appointment
                        if (physicians.Count == 0 || patients.Count == 0)//If there's at least 1 patient & doctor
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You must have at least 1 patient and 1 doctor.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Patient selectedPatient = null;
                            Physician selectedPhysician = null;


                            //Display Patient IDs
                            for (int i = 0; i < patients.Count; i++)
                            {
                                Console.WriteLine($"ID: {patients[i].id} Name: {patients[i].Name}");
                            }

                            //Validate Patient Selection
                            while (selectedPatient == null)
                            {
                                Console.WriteLine("Select using the Patient ID:");
                                string inputID_Patient = Console.ReadLine();
                                selectedPatient = patients.Find(x => x.id == inputID_Patient);
                                if (selectedPatient == null)
                                    Console.WriteLine("Patient not found.");
                            }
                            Console.WriteLine($"Selected {selectedPatient.Name}");


                            //Display Physician IDs
                            for (int i = 0; i < physicians.Count; i++)
                            {
                                Console.WriteLine($"ID: {physicians[i].id} Name: {physicians[i].Name}");
                            }

                            //Validate Physician Selection
                            while (selectedPhysician == null)
                            {
                                Console.WriteLine("Select using the Physician ID:");
                                string inputID_Physician = Console.ReadLine();
                                selectedPhysician = physicians.Find(x => x.id == inputID_Physician);
                                if (selectedPhysician == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Physician not found.");
                                    Console.ResetColor();

                                }
                            }
                            Console.WriteLine($"Selected Dr. {selectedPhysician.Name}.");

                            //Appointment Creation
                            bool appointmentBooked = false;

                            // Loop until a valid appointment time is found
                            while (!appointmentBooked)
                            {
                                // Prompt for the desired appointment date and time
                                DateTime selectedDateTime = DateTime.MinValue; //Needs a default value.
                                bool dateTimeParsed = false;

                                while (!dateTimeParsed)
                                {
                                    Console.WriteLine("Enter the desired appointment date and time (MM-dd-yyyy HH:mm) *Time is 24-hour format*:");
                                    string timeInput = Console.ReadLine();
                                    dateTimeParsed = DateTime.TryParseExact(timeInput, "MM-dd-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out selectedDateTime);
                                    if (!dateTimeParsed)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid date and time format. Please enter the date and time in the format 'MM-dd-yyyy HH:mm'.");
                                        Console.ResetColor();
                                    }
                                }

                                // Check if the selected day is a weekday (Monday-Friday)
                                if (selectedDateTime.DayOfWeek == DayOfWeek.Saturday || selectedDateTime.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Appointments can only be made Monday through Friday.");
                                    Console.ResetColor();
                                    continue; // Prompt again
                                }

                                // Check if the selected time is within business hours (08:00 and 17:00)
                                if (selectedDateTime.TimeOfDay < new TimeSpan(8, 0, 0) || selectedDateTime.TimeOfDay >= new TimeSpan(17, 0, 0))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Appointments can only be scheduled between 8:00 and 17:00.");
                                    Console.ResetColor();
                                    continue; // Prompt again
                                }

                                // Check if the time slot is free (not overlapping with existing appointments)
                                bool isAvailable = true;
                                foreach (var appointment in selectedPhysician.Appointments)
                                {
                                    if (selectedDateTime >= appointment.Date && selectedDateTime < appointment.Date.AddHours(1))
                                    {
                                        isAvailable = false;
                                        break;
                                    }
                                }

                                if (isAvailable)
                                {
                                    // Book the appointment (1-hour duration assumed)
                                    selectedPhysician.Appointments.Add(new Appointment(selectedDateTime, selectedPatient));
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Appointment booked with {selectedPhysician.Name} for {selectedPatient.Name} on {selectedDateTime:dddd, MMM dd yyyy HH:mm}");
                                    Console.ResetColor();
                                    appointmentBooked = true; // Set to true to exit loop
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("The selected time is not available. Please choose another time. Note, appointments are 1 hour in length.");
                                    Console.ResetColor();
                                }
                            }
                        }
                            break;
                    case 'd'://Add a doctor/physician
                        Physician tempPhysician = new Physician();
                        bool valid = false;
                        do
                        {
                            Console.WriteLine("Physician name: ");
                            tempPhysician.Name =  Console.ReadLine();

                            Console.WriteLine("Physician license number:");
                            tempPhysician.LicenseNumber = Console.ReadLine();

                            Console.WriteLine("Graduation date (MM-dd-yyyy): ");
                            tempPhysician.GraduationDate = DateTime.ParseExact(Console.ReadLine(), "MM-dd-yyyy", CultureInfo.InvariantCulture);

                            Console.WriteLine($"Does Dr. {tempPhysician.Name} have any specializations? (y/n):");
                            if(Console.ReadLine().ToLower() == "y")
                            {
                                Console.WriteLine("Type in the specialization then press " +
                                    "the Enter key to add a specialization. Once you are " +
                                    "finished, simply type \"Done\" to record them.");
                                string special;
                                do
                                {
                                    Console.WriteLine("Specialization: ");
                                    special = Console.ReadLine();
                                    if (special.ToLower()!= "done")//prevents "done" as  being added as a specialization                          
                                        tempPhysician.Specializations.Add(special);
                                }
                                while (special.ToLower() != "done");
                            }
                            Console.WriteLine($"{tempPhysician}Is all the information above correct? (y/n)");
                            if(Console.ReadLine().ToLower() == "y")
                                valid = true;

                        } while (!valid);

                        physicians.Add(tempPhysician);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successfully added Dr. {tempPhysician.Name}");
                        Console.ResetColor();
                        break;



                    case 'l'://List things

                        Console.WriteLine("Select something to display: ");
                        Console.WriteLine("[P] List Patients");
                        Console.WriteLine("[D] List Doctors");

                        
                        switch (Console.ReadLine())
                        {
                            case "p":
                                for(int i = 0; i < patients.Count; i++)
                                    Console.WriteLine(patients[i]);

                                break;
                            case "d":
                                for (int i = 0; i < physicians.Count; i++)
                                    Console.WriteLine(physicians[i]);
                                break;

                            default:
                                Console.WriteLine("Invalid input.");
                                break;
                        }

                        break;
                    case '|'://just adds a blank patient & physician for ease of debugging.
                        patients.Add(new Patient());
                        physicians.Add(new Physician());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("DEV");
                        Console.ResetColor();
                        Console.WriteLine(": Added Patient & Physician.");
                        break;
                }
            }
        }
    }
}