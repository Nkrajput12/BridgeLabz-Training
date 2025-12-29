using System;

class SnakeNLadder
{
    //method to generate a random number 1-6
    public static int RandomDice()
    {
        Random rand = new Random(); // declare object of Random Class
        return rand.Next(1,7); // return random number between 1 to 6
    }
    //mehtod for checking snake
    public static int[] CheckSnake(int[,] snake,  int[] score, int chance)
    {
        for(int i = 0; i < snake.GetLength(0); i++)
        {
            if (score[chance] == snake[i , 0]) //check if our score is equal to 1column of snake 
            {
                Console.WriteLine("Oh no! bitten by snake at " + snake[i, 0] + " and down to " + snake[i, 1] + " !");
                score[chance] = snake[i, 1]; //down the score of player to respected 2 column of the snake 
            }
        }

        return score;
    }

    //method for checking for ladder
    public static int[] CheckLadder(int[,] ladder, int[] score, int chance)
    {
        for (int i = 0; i < ladder.GetLength(0); i++)
        {
            if (score[chance] == ladder[i, 0]) //check if our score is equal to 1column of ladder
            {
                Console.WriteLine("Yay! climb a ladder at " + ladder[i, 0] + " and up to " + ladder[i, 1]);
                score[chance] = ladder[i, 1]; // if yes climb the ladder
            }
        }

        return score;
    }

    //mehod for moving
    public static int[] Move(int chance,int roll, int[] score)
    {
        if (score[chance]+roll > 100) //check if score + roll do not exceed 100
        {
            return score; //return score without adding the roll dice value
        }
        else
        {
            score[chance] += roll; 
        }
            return score; //return score after adding the roll dice value
    }

    
    //main method
    public static void Main(string[] args)
    {
        //taking input 
        Console.WriteLine("Enter the number of players");
        int numplayer = Convert.ToInt32(Console.ReadLine());

        if(numplayer<2 || numplayer > 4) //check if number of player is not less than 2 or greater than 4
        {
            Console.Error.WriteLine("the min player is 2 and max player is 4");
            Environment.Exit(0); //successfully terminate the code
        }

        GameStart(numplayer); // call method to start the game
    }




    //mehthod for Game start
    public static void GameStart(int numplayer)
    {
        //intializing string for name input
        string[] name = new string[numplayer];
        for (int i = 0; i < numplayer; i++)
        {
            Console.WriteLine("Enter name of player " + (i + 1));
            name[i] = Console.ReadLine();
        }
        //declaring score array
        int[] score = new int[numplayer];


        //declaring Ladder
        int[,] ladder = {
            {5 , 27 },
            {9,51 },
            {22 , 60 },
            {53 , 69 },
            {44 , 78 }
        };


        //declaring snake
        int[,] snake =
        {
            {99 , 4 },
            {89 , 43 },
            {13 , 7 },
            {91 , 52 },
            {80, 33 }
        };

        int chance = 0;


        while (true) //loop run until one of the player win
        {
            Console.WriteLine(name[chance] + " press 1 to roll the dice ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n == 1) //check if user input the valid value
            {
                int roll = RandomDice();  //call randomdice method to generate the random number and store in roll

                Console.WriteLine("roll = " + roll);

                int old = score[chance]; //saving the old score of player in old

                score = Move(chance, roll, score); //call move method to update score accordingly

                score = CheckSnake(snake, score, chance); // method call for check for snake

                score = CheckLadder(ladder, score, chance);//method call for check for ladder

                int new1 = score[chance];  //store the new score value of the player

                Console.WriteLine(old + " -----> " + new1); //print old and new score



                Console.WriteLine(name[chance] + "'s score = " + score[chance]); //updated score




                for (int i = 0; i < score.Length; i++) // if any player won the code exit successfully
                {
                    if (score[i] >= 100)
                    {
                        Console.WriteLine(name[i] + " win the game ");
                        Environment.Exit(0);
                    }



                }


                chance++;
                if (chance > (numplayer - 1))
                {
                    chance = 0;
                }

            }
            else // if user input wrong 
            {
                Console.WriteLine("please press 1 ");
            }
        }
    }
}

