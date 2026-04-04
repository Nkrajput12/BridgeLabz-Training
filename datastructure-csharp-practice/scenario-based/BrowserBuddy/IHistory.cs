using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BrowserBuddy
{
    internal interface IHistory
    {
        void visit(string data);

        string backwards();

        string forward();
       string GetCurrent();

    }
}
