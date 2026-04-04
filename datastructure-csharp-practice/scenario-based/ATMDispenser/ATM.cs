using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ATMDispenser
{
    internal class ATM
    {
        public static void Main(string[] args)
        {
            ATM atm = new ATM(); //object create for atm class
            int amount = 880;

            //call methods for all 3 scenario 
            Console.WriteLine("-----------Scenario A--------------");
            atm.ScenarioA(amount);
            Console.WriteLine("-----------Scenario B---------------");
            atm.ScenarioB(amount);
            Console.WriteLine("-----------Scenario C----------------");
            atm.ScenarioC(amount);

            

        }

        public void ScenarioA(int amount) //print the number of optimal number of notes for amount
        {
            int remainingAmount = amount;
            int[] notesA = { 500, 200, 100, 50, 20, 10, 5, 2, 1 }; //assign the amounts of notes

            for(int i = 0; i < notesA.Length; i++)
            {
                if(remainingAmount > 0) //check if remaining amount is greter than 0 or not
                {
                    int notes = remainingAmount / notesA[i]; //find the number of notes
                    Console.WriteLine("number of "+notesA[i]+"INR notes = " + notes); //print the number of notes 
                    remainingAmount -= notes * notesA[i]; //find the remaing amount after sub the value of notes

                }

            }
        }

        public void ScenarioB(int amount) // in scenario B remove notes of 500
        {
            int remainingAmount = amount;
            int[] notesA = {200, 100, 50, 20, 10, 5, 2, 1 };

            for (int i = 0; i < notesA.Length; i++)
            {
                if (remainingAmount > 0)
                {
                    int notes = remainingAmount / notesA[i];
                    Console.WriteLine("number of " + notesA[i] + "INR notes = " + notes);
                    remainingAmount -= notes * notesA[i];

                }

            }
        }

        public void ScenarioC(int amount) //fallback combo if chancge is not possible
        {
            int remainingAmount = amount; //amount assign to remaining Amount
            int[] notesA = { 500, 200, 100, 50, 20, 10 };

            for (int i = 0; i < notesA.Length; i++) //loop run until notes lenght
            {
                if (remainingAmount > 0)
                {
                    int notes = remainingAmount / notesA[i]; //find the number of notes required
                    Console.WriteLine("number of " + notesA[i] + "INR notes = " + notes); //print the result
                    remainingAmount -= notes * notesA[i]; //sub the remaining notes

                }

            }

            if(remainingAmount > 0) //check if changes is possible or not
            {
                Console.WriteLine("changes of " + remainingAmount + " isn't possible"); //print result
            }
        }
    }
}
