using System;
class ThreeFriends
{
    public static void Main(string[] args)
    {
        int[] age = new int[3];
        int[] height = new int[3];

        //taking input for age and height
        Console.WriteLine("Enter the age and height of Amar,Akbar and Anthony respectevely");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Friend " + (i + 1) + " age:");
            age[i] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Friend " + (i + 1) + " height");
            height[i] = Convert.ToInt32(Console.ReadLine());
        }

        //finding youngest
        if(YoungestFriend(age)==0)
        {
            Console.WriteLine("Amar is the youngest");
        }
        else if(YoungestFriend(age)==1)
        {
            Console.WriteLine("Akbar is the youngest");
        }
        else
        {
            Console.WriteLine("Anthony is the youngest");
        }

        //finding tallest
        if(TallestFriend(height)==0)
        {
            Console.WriteLine("Amar is the tallest");
        }
        else if(TallestFriend(height)==1)
        {
            Console.WriteLine("Akbar is the tallest");
        }
        else
        {
            Console.WriteLine("Anthony is the tallest");
        }

    }

    //method for finding the youngest friend
    public static int YoungestFriend(int[] age)
    {
        int minAge = age[0];
        int index = 0;
        for (int i = 1; i < 3; i++)
        {
            if (age[i] < minAge)
            {
                minAge = age[i];
                index = i;
            }
        }
        return index;
    }

    //method for finding the tallest friend
    public static int TallestFriend(int[] height)
    {
        int maxHeight = height[0];
        int index = 0;
        for (int i = 1; i < 3; i++)
        {
            if (height[i] > maxHeight)
            {
                maxHeight = height[i];
                index = i;
            }
        }
        return index;
    }


}

