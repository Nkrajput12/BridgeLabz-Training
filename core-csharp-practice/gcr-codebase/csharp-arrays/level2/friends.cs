using System;
class Friends
{
    public static void Main(string[] args)
    {
        int[] age = new int[3];
        int[] height = new int[3];

        //taking inputs 
        Console.WriteLine("Enter the age of Amar,Akbar and Anthony respectevely");
        for(int i  = 0; i < age.Length; i++)
        {
            age[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Enter the height of Amar,Akbar and Anthony respectevely");
        for(int i  = 0; i < height.Length; i++)
        {
            height[i] = Convert.ToInt32(Console.ReadLine());
        }

        int index_age = 0;

        //comparing ages and heights
        for(int i = 0; i < age.Length; i++)
        {
            //find the index with maximum height
            if (age[i] < age[index_age])
            {

                index_age = i;

            }
        }

        int index_height = 0;
        //comparing heights
        for(int i = 0; i < height.Length; i++)
        {
            //find the index with maximum height
            if (height[i] > height[index_height])
            {

                index_height = i;

            }
        }
        //print who is the youngest
        if (index_age == 0)
        {
            Console.WriteLine("Amar is the youngest");
        }
        else if(index_age == 1)
        {
            Console.WriteLine("Akbar is the youngest");
        }
        else
        {
            Console.WriteLine("Anthony is the youngest");
        }

        //print who is the tallest
        if (index_height == 0)
        {
            Console.WriteLine("Amar is the tallest");
        }
        else if(index_height == 1)
        {
            Console.WriteLine("Akbar is the tallest");
        }
        else
        {
            Console.WriteLine("Anthony is the tallest");
        }

    }
}