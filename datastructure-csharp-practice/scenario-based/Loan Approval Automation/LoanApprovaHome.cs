using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    public class LoanApprovaHome
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Credit Score: ");
            int creditScore = int.Parse(Console.ReadLine());
            Console.Write("Enter Income: ");
            double income = double.Parse(Console.ReadLine());
            Console.Write("Enter Loan Amount: ");
            double loanAmount = double.Parse(Console.ReadLine());
            Console.Write("Enter the Loan Term: ");
            int term = int.Parse(Console.ReadLine());

            LoanApprovalMenu menu = new LoanApprovalMenu();
            menu.Run(name, creditScore,income,loanAmount,term);
        }
    }
}
