using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    public class Applicant
    {
        private string Name;
        protected int CreditScore;
        protected double income;
        protected double LoanAmount;

        public Applicant(string name , int creditScore, double income, double loanAmount)
        {
            Name = name;
            CreditScore = creditScore;
            this.income = income;
            LoanAmount = loanAmount;
        }

        public void Display()
        {
            Console.WriteLine("-----------Costumer Details-----------");
            Console.WriteLine("Name = " + Name);
            Console.WriteLine("CreditScore = "+CreditScore);
            Console.WriteLine("Income = "+income);
            Console.WriteLine("Loan Amount" + LoanAmount);
        }
    }
}
