using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AmbulanceRoute
{
    internal class HospitalUnit
    {
        public string Name { get; set; }
        public int Capacity { get; set;}
        public bool IsAvailable => PatientCount < Capacity;

        public int PatientCount;

        public HospitalUnit Next;
        public HospitalUnit(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.PatientCount = 0;
        }
    }
}
