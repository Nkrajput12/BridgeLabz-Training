using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    internal class AutoLoan : LoanApplication
    {
        double InterestRate = 15.5;
        public AutoLoan(string name, int creditScore, double income, double loanAmount, int Term) : base("Auto Loan", Term, 15.5, name, creditScore, income, loanAmount) { }

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
            if (ApproveLoan())
            {
                base.EmiPerMonth = GetEmi();
                return GetEmi();

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
