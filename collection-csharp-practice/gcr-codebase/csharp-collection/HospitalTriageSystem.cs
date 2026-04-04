using System;
using System.Collections.Generic;

namespace BridgeLabzTraining.access
{
    internal record Patient(string Name, int Severity, int ArrivalOrder);

    internal class HospitalTriage
    {
        public static void Main(string[] args)
        {
            var patients = new List<Patient>
            {
                new Patient("John", 3, 1),
                new Patient("Alice", 5, 2),
                new Patient("Bob", 2, 3),
                new Patient("Charlie", 5, 4)
            };

            var treatmentOrder = GetTreatmentOrder(patients);

            Console.WriteLine("Treatment order:");
            foreach (var p in treatmentOrder)
            {
                Console.WriteLine($"{p.Name} (Severity: {p.Severity}, Arrival: {p.ArrivalOrder})");
            }
        }

        public static List<Patient> GetTreatmentOrder(IEnumerable<Patient> patients)
        {
            // Custom comparer: Higher severity first, then lower arrival order
            var triageComparer = Comparer<(int Severity, int Arrival)>.Create((x, y) =>
            {
                int priority = y.Severity.CompareTo(x.Severity);
                return priority != 0 ? priority : x.Arrival.CompareTo(y.Arrival);
            });

            var pq = new PriorityQueue<Patient, (int Severity, int Arrival)>(triageComparer);

            foreach (var p in patients)
            {
                pq.Enqueue(p, (p.Severity, p.ArrivalOrder));
            }

            var result = new List<Patient>();
            while (pq.Count > 0)
            {
                result.Add(pq.Dequeue());
            }

            return result;
        }
    }
}