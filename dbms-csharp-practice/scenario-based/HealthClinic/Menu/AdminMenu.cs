using System;

public class AdminMenu
{
    public void Admin()
    {
        SpecialtyUtility specialty = new SpecialtyUtility();
        DoctorUtility doctor = new DoctorUtility();
        BillUtility bill = new BillUtility();
        AdminUtility admin = new AdminUtility();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Press 1: Add Specialty");
            Console.WriteLine("Press 2: Add Doctor");
            Console.WriteLine("Press 3: Update Doctor Specialty");
            Console.WriteLine("Press 4: Deactivate Doctor");
            Console.WriteLine("Press 5: Generate Revenue Report");
            Console.WriteLine("Press 6: View System Audit Logs");
            Console.WriteLine("Press 7: Backup data");
            Console.WriteLine("Press 8: Exit");
            
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                specialty.AddSpecialty();
                break;

                case "2":
                doctor.AddDoctor();
                break;

                case "3":
                doctor.UpdateSpecialty();
                break;

                case "4":
                doctor.DeactivateDoctor();
                break;

                case "5":
                bill.GenerateRevenueReport();
                break;

                case "6":
                admin.ShowAuditLogs();

                break;

                case "7":
                admin.BackupPatientData();
                break;
                
                case "8":
                exit = true;
                break;

                default:
                Console.WriteLine("Invalid Choice");
                break;
            }
                
            
        }
    }
}