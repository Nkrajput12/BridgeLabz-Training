using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    public abstract class LoanApplication : Applicant, IApproval
    {
        private string LoanType;
        protected int Term;
        private double InterestRate;
        protected string LoanStatus;
        protected double EmiPerMonth;

        public LoanApplication(string LoanType, int Term, double InterestRate, string name , int creditScore, double income, double loanAmount) : base(name, creditScore, income, loanAmount)
        {
            this.LoanType = LoanType;
            this.Term   = Term;
            this.InterestRate = InterestRate;
        }
        
        public abstract bool ApproveLoan();

        public abstract double CalculateEmi();

        public void Display()
        {
            
            base.Display();
            Console.WriteLine("---------Loan Details--------");
            Console.WriteLine("Loan Type: "+LoanType);
            Console.WriteLine("Term: "+Term);
            Console.WriteLine("Interest Rate: " + InterestRate+"%");
            Console.WriteLine("Loan Status: " + LoanStatus);
            Console.WriteLine("Emi per Month: "+EmiPerMonth);
        }

    }
}
