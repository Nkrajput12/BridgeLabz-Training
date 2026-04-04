using System;
class Friends{
    static void Main(string[]args) {
		//taking inputs
        Console.WriteLine("Enter Amar's age: ");
        int ageamar = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Amar's height: ");
        double hamar = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Akbar's age: ");
        int ageakbar = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Akbar's height: ");
        double hakbar = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter Anthony's age: ");
        int ageanthony = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Anthony's height: ");
        double hanthony = Convert.ToDouble(Console.ReadLine());
		
		//compare their age
        if (ageamar < ageakbar && ageamar < ageanthony) {
            Console.WriteLine("Youngest friend is Amar");
        } else if (ageakbar < ageanthony) {
            Console.WriteLine("Youngest friend is Akbar");
        } else {
            Console.WriteLine("Youngest friend is Anthony");
        }
		
		//comapare their height
        if (hamar > hakbar && hamar > hanthony) {
            Console.WriteLine("Tallest friend is Amar");
        } else if (hakbar > hanthony) {
            Console.WriteLine("Tallest friend is Akbar");
        } else {
            Console.WriteLine("Tallest friend is Anthony");
        }
    }
}