using System;

public class DoctorMenu
{
    PatientUtility patient = new PatientUtility();
    VisitUtility visit = new VisitUtility();
    public void Doctor()
    {
        
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Press 1: Search Patient");
            Console.WriteLine("Press 2: Record Visit");
            Console.WriteLine("Press 3: View Patient visit History");
            Console.WriteLine("Press 4: Exit");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                patient.SearchPatient();
                break;

                case "2":
                visit.RecordVisit();
                break;

                case "3":
                visit.ViewPatientHistory();
                break;

                case "4":
                exit = true;
                break;

                default:
                Console.WriteLine("Invalid Choice");
                break;
            }
        }

    }
}