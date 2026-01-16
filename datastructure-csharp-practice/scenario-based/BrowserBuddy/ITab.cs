using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BrowserBuddy
{
    public interface ITab
    {
        void Push(string data);

        string Pop();
    }
}
