using System;
class EduQuiz
{
    //main method
    public static void Main(string[] args)
    {
        //taking input for student name
        Console.WriteLine("Please Enter your name");
        string name = Console.ReadLine() ?? "";

        //declaring a object 
        EduQuiz obj = new EduQuiz();

        Console.WriteLine("---------------------Quiz start----------------------");
        obj.QuizStart(name);
    }

    //method which have quiz question and there answer-----------------------------------------------------------------------------------------------------------
    string[,] Question()
    {
        string[,] questions = new string[10, 2] // declaring a 2d array which contaion question and answer
        {
            { "Which planet is known as the Red Planet?", "Mars" },
            { "What is the largest planet in our solar system?", "Jupiter" },
            { "Which galaxy is home to the Solar System?", "Milky Way" },
            { "What is the hottest planet in our solar system?", "Venus" },
            { "Who was the first human to travel into space?", "Yuri Gagarin" },
            { "What is the name of Earth's only natural satellite?", "Moon" },
            { "Which planet is famous for its prominent ring system?", "Saturn" },
            { "What is the closest star to Earth?", "Sun" },
            { "In which year did man first land on the moon?", "1969" },
            { "What is the term for a star that has collapsed under its own gravity?", "Black Hole" }
        };

        return questions; //return the question string 
    }

    //method for start the quiz which take input from students--------------------------------------------------------------------------------------------------
    void QuizStart(string name)
    {
        EduQuiz ob = new EduQuiz();//declaration of object
        string[,] question = ob.Question(); //call the question method and store the value in question 

        string[] studentAns = new string[question.GetLength(0)]; //this is use to store the answer of student

        int i = 0; //intiallizing for iteration
        while (i < 10) //loop for taking input from student and store it in student answer string
        {
            Console.WriteLine("question no "+(i+1)+"." + question[i, 0]); // show question to the students
            Console.Write("Answer here: ");
            studentAns[i] = Console.ReadLine() ?? ""; //taking input from student
            i++;
        }

        int score = Score(question, studentAns); //call method score to show the detail feedback and find the score
        Console.WriteLine(score);
        float percentage = score*100f / studentAns.Length; //formula to calculate the score


        Console.WriteLine(name+" your percentage is " + percentage); //print the score

        if(percentage < 30) //check for pass or fail if less than 30% fail else fail
        {
            Console.WriteLine("Fail");
        }
        else
        {
            Console.WriteLine("Pass");
        }


    }

    //method use to calculate the score and give detail feedback--------------------------------------------------------------------------------------------------------------
    int Score(string[,] question , string[] studentAns)
    {
        int score = 0; //intially the score is zero
        for(int i = 0; i < question.GetLength(0)-1; i++)
        {
            if (string.Equals(question[i,1], studentAns[i], StringComparison.OrdinalIgnoreCase)) //comapare the answer of the students with correct one case-insensetive
            {
                Console.WriteLine("Answer no " + (i + 1) + " is correct");
                score++; //increse score by 1 if answer is correct
            }
            else
            {
                Console.WriteLine("your answer is incorrect the correct answer is "+question[i, 1]);
            }

        }
        return score;
    }

    

}
