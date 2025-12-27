using System;

class SnakeNLadder
{
    //method to generate a random number 1-6
    public static int RandomDice()
    {
        Random rand = new Random();
        return rand.Next(1,7);
    }
    //mehtod for checking snake
    public static int[] CheckSnake(int[,] snake,  int[] score, int chance)
    {
        for(int i = 0; i < snake.GetLength(0); i++)
        {
            if (score[chance] == snake[i , 0])
            {
                Console.WriteLine("Oh no! bitten by snake at " + snake[i, 0] + " and down to " + snake[i, 1] + " !");
                score[chance] = snake[i, 1];
            }
        }

        return score;
    }

    //method for checking for ladder
    public static int[] CheckLadder(int[,] ladder, int[] score, int chance)
    {
        for (int i = 0; i < ladder.GetLength(0); i++)
        {
            if (score[chance] == ladder[i, 0])
            {
                Console.WriteLine("Yay! climb a ladder at " + ladder[i, 0] + " and up to " + ladder[i, 1]);
                score[chance] = ladder[i, 1];
            }
        }

        return score;
    }

    //mehod for moving
    public static int[] Move(int chance,int roll, int[] score)
    {
        if (score[chance]+roll > 100)
        {
            return score;
        }
        else
        {
            score[chance] += roll;
        }
            return score;
    }

    

    public static void Main(string[] args)
    {
        //taking input 
        Console.WriteLine("Enter the number of players");
        int numplayer = Convert.ToInt32(Console.ReadLine());
        if(numplayer<2 || numplayer > 4)
        {
            Console.Error.WriteLine("the min player is 2 and max player is 4");
            Environment.Exit(0);
        }

        //intializing string for name input
        string[] name = new string[numplayer];
        for(int i = 0; i < numplayer; i++)
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


        while (true) 
        {
            Console.WriteLine(name[chance] + " press 1 to roll the dice ");
            int n = Convert.ToInt32(Console.ReadLine());
            if(n == 1)
            {
                int roll = RandomDice();
                Console.WriteLine("roll = " + roll);
                score = Move(chance, roll, score);

                score = CheckSnake(snake, score, chance);

                score = CheckLadder(ladder, score, chance);

                for(int i = 0; i < score.Length; i++)
                {
                    Console.WriteLine(name[i] + "'s score = " + score[i]);

                    
                }

                for (int i = 0; i < score.Length; i++)
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
            else
            {
                Console.WriteLine("please press 1 ");
            }
        }



    }
}

