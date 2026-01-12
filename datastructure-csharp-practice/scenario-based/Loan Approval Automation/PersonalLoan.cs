using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    internal class PersonalLoan : LoanApplication
    {
        double InterestRate = 15;

        public PersonalLoan(string name, int creditScore, double income, double loanAmount, int Term):base("Personal Loan", Term, 15, name, creditScore, income, loanAmount) { }

        //method to calculate the Emi per month
        private double GetEmi()
        {
            double rate = InterestRate / (12 * 100);

            int monthsNum = base.Term * 12;

            double powerfactor = Math.Pow(1 + rate, monthsNum);

            double emi = base.LoanAmount * rate * (powerfactor / (powerfactor - 1));


            return emi;
        }

        public override bool ApproveLoan()
        {
            if (base.CreditScore < 700 || base.income < GetEmi()) //check for credit score and Income 
            {

                base.LoanStatus = "Not Approved";
                return false;
            }
            else
            {
                //Console.WriteLine("Loan Approved");
                base.LoanStatus = "Approved";
                return true;
            }
        }

        public override double CalculateEmi()
        { 
            if (ApproveLoan()) //if loan is approved
            { 
                base.EmiPerMonth = GetEmi(); //assign Emi per month
                return GetEmi(); //return the Emi

            }
            else
            {
                return 0;
            }
        }

        public void Display()
        {
            base.Display();
        }
    }
}

