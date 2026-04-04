using System;
class WordSplit{
   
    // method to split words
    static string[,] SplitWords(string text){
        // Counter
        int Count = 1;
        for(int i = 0;i<text.Length;i++){
            if(text[i] == ' ')
                Count++;
        }

        
        string[,] result = new string[Count, 2];
        string Word = "";
        int j = 0;

        for(int i = 0;i<=text.Length;i++){
            if(i == text.Length || text[i] == ' '){
                // Store word and its length
                result[j, 0] = Word; //store current word to 2d array
                result[j, 1] = Word.Length.ToString(); //calculate the words length;
                Word = ""; //assign null to "Word"
                j++;
            }
            else{
                Word += text[i]; 
            }
        }
        return result;
    }

    public static void Main(string[]args)
    {
        //taking input from user
        Console.Write("Enter the text ");
        string word = Console.ReadLine();

        //calling method
        string[,] result = SplitWords(word);

        //print results 
        Console.WriteLine("Word\tLength");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            Console.WriteLine($"{result[i, 0]}\t{result[i, 1]}");
        }
    }

}