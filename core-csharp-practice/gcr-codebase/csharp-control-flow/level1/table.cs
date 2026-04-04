using System;
class Table{
    public static void Main(string[]args){
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i=6;i<=9;i++){
            int result = number * i;
            Console.WriteLine(number + " * " + i + " = " + result);
        }
    }
}