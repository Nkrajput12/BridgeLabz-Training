using System;
using System.Text;
class SentenceFormatter
{
    //mehod for add one space after punctuation 
    public static string AddSpace(string text)
    {

        string sb = ""; //intiallizing the empty string 
        for (int i = 0; i < text.Length-1; i++)
        {
            char c = text[i];
            
             if (char.IsPunctuation(c)) // check for the punctuation
             {
                 sb += c;
                 sb += " "; //if there is a punctuation then add a space after it
             }
             else
             {
                sb += c;
             }
        }
        sb += text[text.Length - 1]; //add last character to the string because last character is mainly punctuation and we don't want to add space in front of it
        return sb;
            
    }

    //method for trim the spaces
    public static string TrimSpace(string text)
    {
        string sb = "";
        for(int i = 0;i< text.Length ; i++)
        {
            char c = text[i];
  
            if(!(c== ' ' && text[i+1]==' ')) //check for space after the space if this is not true then add element
            {
                sb += c;
            }
        }
        return sb;
    }

    //mehod to captilize the letter after period/question mark and exclamation mark
    public static string Capital(string text)
    {
        string sb = "";
        sb += char.ToUpper(text[0]); //capitialize the first letter
        if (text.Length == 1) return sb; //if the text length is equal to 1 
        sb += text[1]; // add the second letter to sb
        for(int i=2;i< text.Length; i++)
        {
            char c = text[i-2];
            if(c == '!' || c== '?' || c == '.') //check for the !/?/. 2 char before
            {
                sb += char.ToUpper(text[i]); // if the above condition is true capitalize the letter
            }
            else
            {
                sb += text[i]; 
            }
        }
        
        return sb;
    }

    //main method 
    public static void Main(string[] args)
    {
        //taking input
        Console.WriteLine("Enter the text");
        string text = Console.ReadLine() ?? "";

        //call dispay method
        Display(text);
        
    }

    //method for display
    public static void Display(string text)    
    {
        string space = AddSpace(text); // call method to add spaces in front of punctuation
        string trim = TrimSpace(space); //call method to trim the extra spaces
        string capital = Capital(trim); //call method to captilize the first letter after the ./!/?.
        Console.WriteLine(capital);
    }

}
