using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Loan_Approval_Automation
{
    internal interface IApproval
    {
        public bool ApproveLoan();

        public double CalculateEmi();
    }
}
