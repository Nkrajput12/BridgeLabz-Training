using System;

public class RoleMenu
{
    ReceptionistMenu receptionistMenu = new ReceptionistMenu();
    AdminMenu adminMenu = new AdminMenu();

    DoctorMenu doctor = new DoctorMenu();
    public void SelectRole()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Press 1 For Receptionist Login");
            Console.WriteLine("Press 2 for Doctor Login");
            Console.WriteLine("Press 3 for Admin Login");
            Console.WriteLine("Press 4 for exit");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                receptionistMenu.Receptionist();
                break;

                case "2":
                doctor.Doctor();
                break;

                case "3":
                adminMenu.Admin();
                break;

                case "4":
                exit = true;
                break;

                default:
                Console.WriteLine("Invalid Input");
                break;
            }
        }
    }
}