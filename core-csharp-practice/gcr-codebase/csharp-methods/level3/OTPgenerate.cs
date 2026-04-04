using System;
public class OTPgenerate
{
    //method to generate a 6-digit OTP
    public static int GenerateOTP()
    {
        Random random = new Random();
        int otp = random.Next(100000, 999999);
        return otp;
    }

    //method to save otp in an array 10 times
    public static int[] SaveOTP(int otp)
    {
        int[] otpArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            otpArray[i] = GenerateOTP();
        }
        return otpArray;
    }

    //method to ensure all otp are unique in the array
    public static bool IsUnique(int[] otpArray)
    {
        for (int i = 0; i < otpArray.Length; i++)
        {
            for (int j = i + 1; j < otpArray.Length; j++)
            {
                if (otpArray[i] == otpArray[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void Main(string[] args)
    {
        int otp = GenerateOTP();
        Console.WriteLine("Generated OTP: " + otp);
        int[] otpArray = SaveOTP(otp);
        for(int i = 0; i < otpArray.Length; i++ ) {
        {
            Console.WriteLine("OTP " + (i + 1) + ": " + otpArray[i]);
        }
        bool unique = IsUnique(otpArray);
        Console.WriteLine("Are all OTPs unique? " + unique);
        }

    }
}




