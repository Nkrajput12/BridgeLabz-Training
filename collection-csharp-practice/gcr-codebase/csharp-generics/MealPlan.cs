
using System;

// Meal interface
interface IMealPlan
{
    string GetMeal();
}

class VegetarianMeal : IMealPlan
{
    public string GetMeal()
    {
        return "Vegetarian Meal Selected";
    }
}

// Generic meal generator
class Meal<T> where T : IMealPlan, new()
{
    public void Generate()
    {
        T meal = new T();
        Console.WriteLine(meal.GetMeal());
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Vegetarian");
        Console.Write("Select Meal: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Meal<VegetarianMeal> meal = new Meal<VegetarianMeal>();
            meal.Generate();
        }
    }
}
