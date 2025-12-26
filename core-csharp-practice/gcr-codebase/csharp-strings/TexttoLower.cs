using System;

class TexttoLower
{
	//method to convert text to lowercase by char manipulation
	public static string ConvertToLower(string text)
	{
		char[] carray = text.ToCharArray();

		for(int i = 0; i < carray.Length; i++)
		{
            if (carray[i] >= 'A' && carray[i] <= 'Z')
            {
                carray[i] = (char)(carray[i] - 'A' + 'a');
            }
        }

		return new string(carray);

	}

	public static void Main(string[] args)
	{
		//taking input from user
		Console.WriteLine("enter text");
		string text = Console.ReadLine();

		//calling method
		string manual = ConvertToLower(text);
		string built = text.ToLower();//build in method


		Console.WriteLine("by char manipulation = "+manual);
		Console.WriteLine("by built in method = "+built);

		bool result = built.Equals(manual);
        if(result) Console.WriteLine("both strings are equal");
        else Console.WriteLine("both strings are not equal");
    }
}
