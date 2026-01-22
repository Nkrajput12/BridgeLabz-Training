using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AmbulanceRoute
{
    internal class RouteManager : IHospital
    {
        private HospitalUnit Head;
        private HospitalUnit Tail;

        public void AddBuilding(string name,int capacity)
        {
            HospitalUnit newBuilding = new HospitalUnit(name, capacity);

            if(Head == null)
            {
                Head = newBuilding;
                Tail = newBuilding;
                newBuilding.Next = Head;
                Console.WriteLine("New unit " + name + " With capacity " + capacity + " Added successfully");
            }
            else
            {
                Tail.Next = newBuilding;
                Tail = newBuilding;
                Tail.Next = Head;
                Console.WriteLine("New unit " + name + " With capacity " + capacity + " Added successfully");
            }
        }

        public void FindNearestunit(string starting)
        {
            if(Head == null)
            {
                Console.WriteLine("There is no Unit");
                return;
            }
            HospitalUnit Current = Head;
            while(Current.Name.ToLower() != starting.ToLower())
            {
                Current = Current.Next;
            }

            HospitalUnit startingPoint = Current;
            do
            {
                if (Current.IsAvailable)
                {
                    Current.PatientCount++;
                    Console.WriteLine("The patient is Addmitted to " + Current.Name);
                    return;
                }
                Console.WriteLine(Current.Name + " Is full .Checking for " + Current.Next.Name);
                Current = Current.Next;
            }
            while (Current != startingPoint);

            Console.WriteLine("All units are Full");
        } 

        public void RemvoveForMaintanace(string name)
        {
            HospitalUnit Current = Head;
            HospitalUnit previous = Tail;

            do
            {
                if (Current.Name == name)
                {
                    if (Current == Head && Current == Tail) //if there a single Unit
                    {
                        Head = null;
                        Tail = null;

                    }
                    else
                    {
                        previous.Next = Current.Next;
                        if (Current == Head) Head = Current.Next;
                        if (Current == Tail) Tail = previous;

                    }
                    Console.WriteLine("Unit Name " + name + " Removed for maintanace ");
                    return;
                }
                previous = Current;
                Current = Current.Next;
            }while(Current != Head);

            Console.WriteLine(name + " Unit Nod Found!!");
        }

        //method to display all units
        public void Display()
        {

            if(Head == null)
            {
                Console.WriteLine("There is no unit");

            }
            else
            {
                HospitalUnit current = Head;
                do
                {
                    Console.WriteLine("Name: " + current.Name);
                    Console.WriteLine("Capacity: " + current.Capacity);
                    Console.WriteLine("Number of Patient: " + current.PatientCount);
                    Console.WriteLine("---------------------------------------------------------------");
                    current = current.Next;
                }
                while (current != Head);
            }
        }
    }
}
