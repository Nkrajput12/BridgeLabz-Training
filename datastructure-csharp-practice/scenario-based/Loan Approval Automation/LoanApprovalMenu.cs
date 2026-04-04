using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    internal class LoanApprovalMenu
    {
        public void Run(string name, int creditScore, double income, double loanAmount, int term)
        {

            LoanApplication loan = null;
            Console.WriteLine("Press 1 for Personal Loan");
            Console.WriteLine("Press 2 for Home Loan");
            Console.WriteLine("Press 3 for Auto Loan");
            Console.Write("Input Here: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                loan = new PersonalLoan(name, creditScore, income, loanAmount, term);
            }
            else if (choice == 2)
            {
                loan = new HomeLoan(name, creditScore, income, loanAmount, term);
            }
            else if (choice == 3)
            {
                loan = new AutoLoan(name, creditScore, income, loanAmount, term);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Press 1 for Check for Loan Approval");
                Console.WriteLine("Press 2 for Calculate the Emi");
                Console.WriteLine("press 3 for Display all the details");
                Console.WriteLine("press 4 for exit");
                Console.Write("Input Here: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        bool check = loan.ApproveLoan();
                        if (check)
                        {
                            Console.WriteLine("Your Loan is approved");
                        }
                        else
                        {
                            Console.WriteLine("your Loan is not approved");

                        }
                        break;

                    case 2:
                        double emi = loan.CalculateEmi();
                        if (emi == 0)
                        {
                            Console.WriteLine("Your Loan is not Approved");
                        }
                        else
                        {
                            Console.WriteLine("your monthly emi is " + emi + " for " + term + "years");
                        }
                        break;

                    case 3:
                        loan.Display();
                        break;

                    case 4:
                        exit = true;
                        break;
                    
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
            }
        }
    }
}
