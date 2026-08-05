using System;
using HealthClinic.Services;
namespace HealthClinic.Menu
{
    public class Menu
    {
        public void Run()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Press 1. Handle Patients");
                Console.WriteLine("Press 2. Handle Doctors");
                Console.WriteLine("Press 3. Handle Appointment");
                Console.WriteLine("Press 4. Handle Billing");
                Console.WriteLine("Press 5. AuditLogs");
                Console.WriteLine("Press 6. Exit");

                string c = Console.ReadLine() ?? "";

                switch (c)
                {
                    case "1":
                        HandlePatient();
                        break;
                    case "2":
                        HandleDoctor();
                        break;
                    case "3":
                        HandleAppointment();
                        break;
                    case "4":
                        HandleBilling();
                        break;
                    case "5":
                        var audit = new AuditLogService();
                        audit.ShowAll();
                        break;
                    case "6":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;

                }
            }
        }

        //Method for Handle Patients
        public static void HandlePatient()
        {
            PatientService patient = new PatientService();
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Press 1: Register Patient");
                Console.WriteLine("Press 2: Update Patient");
                Console.WriteLine("Press 3: Delete Patient");
                Console.WriteLine("Prees 4: See All Patient");
                Console.WriteLine("Press 5: Track Visit History");
                Console.WriteLine("Press 6: back");

                string c = Console.ReadLine() ?? "";

                switch (c)
                {
                    case "1":
                        patient.RegisterPatient();
                        break;
                    case "2":
                        patient.UpdatePatient();
                        break;
                    case "3":
                        patient.DeletePatient();
                        break;
                    case "4":
                        patient.ShowAll();
                        break;
                    case "5":
                        patient.VisitHistory();
                        break;
                    case "6":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }

            }
        }

        public static void HandleDoctor()
        {
            DoctorService Doc = new DoctorService();
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Press 1: Register Doctor");
                Console.WriteLine("Press 2: Update Doctor");
                Console.WriteLine("Press 3: Delete Doctor");
                Console.WriteLine("Press 4: See All Doctors");
                Console.WriteLine("Press 5: back");

                string c = Console.ReadLine() ?? "";

                switch (c)
                {
                    case "1":
                        Doc.AddDoctor();
                        break;
                    case "2":
                        Doc.UpdateDoctor();
                        break;
                    case "3":
                        Doc.DeleteDoctor();
                        break;
                    case "4":
                        Doc.ShowAll();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }

            }
        }

        //Method to Handle Appointment
        public static void HandleAppointment()
        {
            AppointmentService app = new AppointmentService();

            bool back = false;
            while (!back)
            {
                Console.WriteLine("Press 1: Book Appointment");
                Console.WriteLine("Press 2: Update Appointment");
                Console.WriteLine("Press 3: Delete Appointment");
                Console.WriteLine("Press 4: See All Appointments");
                Console.WriteLine("Press 5: back");

                string c = Console.ReadLine() ?? "";

                switch (c)
                {
                    case "1":
                        app.BookAppointment();
                        break;
                    case "2":
                        app.UpdateAppointment();
                        break;
                    case "3":
                        app.CancelAppointment();
                        break;
                    case "4":
                        app.ShowAll();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            }
        }

        public static void HandleBilling()
        {
            BillingService app = new BillingService();

            bool back = false;
            while (!back)
            {
                Console.WriteLine("Press 1: Get Bill by patientid");
                Console.WriteLine("Press 2: Update status to paid");
                Console.WriteLine("Press 3: See All Appointments");
                Console.WriteLine("Press 4: back");

                string c = Console.ReadLine() ?? "";

                switch (c)
                {
                    case "1":
                        app.GetBillingByPatientID();
                        break;
                    case "2":
                        app.UpdatePaymentStatus();
                        break;
                    case "3":
                        app.ShowAll();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            }
        }
    }
}