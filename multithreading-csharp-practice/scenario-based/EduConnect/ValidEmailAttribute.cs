using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BridgeLabzTraining.EduConnect
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class ValidEmailAttribute : Attribute
    {
    }
}
