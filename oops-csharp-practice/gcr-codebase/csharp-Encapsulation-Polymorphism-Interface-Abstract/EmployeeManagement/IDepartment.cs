using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EmployeeManagement
{
    internal interface IDepartment
    {
        void AssignDepartment(string deptName);
        string GetDepartmentName();
    }
}
