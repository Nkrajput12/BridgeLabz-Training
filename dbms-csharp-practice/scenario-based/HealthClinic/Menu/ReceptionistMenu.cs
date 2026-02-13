using System;

public class ReceptionistMenu
{

    PatientUtility patient = new PatientUtility();
    DoctorUtility doctor = new DoctorUtility();
    BillUtility bill = new BillUtility();   
    VisitUtility visit = new VisitUtility();

    AppointmentUtility appointment = new AppointmentUtility();
    public void Receptionist()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Press 1: Register");
            Console.WriteLine("Press 2: Update patient information");
            Console.WriteLine("Press 3: Search Patient");
            Console.WriteLine("Press 4: view Doctor by specialty");
            Console.WriteLine("Press 5: Book New Appointment");
            Console.WriteLine("Press 6: Check Doctor Availability");
            Console.WriteLine("Press 7: Cancel Appointment");
            Console.WriteLine("Press 8: Reschedule Appointment");
            Console.WriteLine("Press 9: Generate Bill");
            Console.WriteLine("Press 10: view Outstanding bill");
            Console.WriteLine("Press 11: Process Outstanding bills");
            Console.WriteLine("Press 12: View Patient Visit History");
            Console.WriteLine("Press 13: Exit");
            
            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                patient.RegisterPatient();
                break;
                
                case "2":
                patient.UpdatePatient();
                break;

                case "3":
                patient.SearchPatient();
                break;
                
                case "4":
                doctor.GetDoctorBySpecialty();
                break;

                case "5":
                appointment.BookAppointment();
                break;

                case "6":
                appointment.CheckAvailability();
                break;

                case "7":
                appointment.CancelAppointment();
                break;

                case "8":
                appointment.RescheduleAppointment();
                break;

                case "9":
                bill.GenerateBill();
                break;

                case "10":
                bill.ViewOutstandingBills();
                break;

                case "11": 
                bill.ProcessOutstandingPayment(); 
                break;

                case "12":
                visit.ViewPatientHistory();
                break;

                case "13":
                exit = true;
                break;

                default :
                Console.WriteLine("Invalid Input");
                break;
            }
        }
    }
}