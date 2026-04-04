using System;

class NumberChecker3
{
    //method for cound the digit
    public static int CountDigits(int n)
    {
        return n.ToString().Length;
    }

    //store elements in an array
    public static int[] GetDigits(int n)
    {
        int len = CountDigits(n);
        int[] digits = new int[len];
        int num = n;
        for (int i = len - 1; i >= 0; i--)
        {
            digits[i] = num % 10;
            num /= 10;
        }
        return digits;
    }

    //method for reversig the array
    public static int[] ReverseDigits(int n)
    {
        int[] digits = GetDigits(n);
        int len = digits.Length;
        int[] rev = new int[len];
        for (int i = 0; i < len; i++)
        {
            rev[i] = digits[len - 1 - i];
        }
        return rev;
    }

    //compare two arrays
    public static bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }

    //method check palindrome
    public static bool IsPalindrome(int n)
    {
        int[] original = GetDigits(n);
        int[] reversed = ReverseDigits(n);
        return AreArraysEqual(original, reversed);
    }

    //method check duck number
    public static bool IsDuck(int n)
    {
        int[] digits = GetDigits(n);
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static void Main(string[]args)
    {
        //taking input from the user
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digits count: " + CountDigits(n));
        for(int i  = 0; i < n; i++)
        {
                        Console.WriteLine("Digit at index " + i + ": " + GetDigits(n)[i]);
        }
        Console.WriteLine("Reversed digits: " + string.Join(",", ReverseDigits(n)));
        Console.WriteLine("Palindrome? " + IsPalindrome(n));
        Console.WriteLine("Duck number? " + IsDuck(n));
    }
}