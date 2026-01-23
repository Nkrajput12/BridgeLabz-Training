using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class MultipleException
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] str = { null, "apple", "car" }; //string array with null element
                Console.WriteLine("Accessing element at index 5: " + str[5]); //try to access an out-of-bounds index
                //checking for null reference
                if (str[0] == null)
                {
                    throw new NullReferenceException("The first element is null.");
                }
            }
            catch (IndexOutOfRangeException ex) //catching index out of range exception
            {
                Console.WriteLine("IndexOutOfRangeException caught: " + ex.Message);
            }
            catch (NullReferenceException ex)   //catching null reference exception
            {
                Console.WriteLine("NullReferenceException caught: " + ex.Message);
            }
            catch (Exception ex)//catching general exception
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
