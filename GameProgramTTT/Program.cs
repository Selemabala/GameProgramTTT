using System;

namespace GameProgramTTT;

class Program
{
    static void Main(string[] args)
    {
        char nextPlayer;
        char[,] grid = new char[3, 3];
        bool play = false; ;

        UI.WelcomeMessage();

        Console.WriteLine($"The game will take between {Identifiers.MIN_PLAYING_TIME} to {Identifiers.MAX_PLAYING_TIME} minutes.");
        char userInput = UI.userInput();


        if (userInput == Identifiers.userLowKey || userInput == Identifiers.userUpperKey)
        {

            play = true;
        }
        else
        {

            play = false;
        }

        bool continuePlaying;
        continuePlaying = play;

        if (continuePlaying == false)
        {
            Console.WriteLine("The game will end ");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Lets go on");
        }

        grid = Logic.CreateEmptyGrid();


        UI.DisplayingWholeGrid(grid);


        bool AIisStarting = UI.GameStarter();

        if (AIisStarting == false)
        {
            nextPlayer = Identifiers.human;
        }
        else
        {
            nextPlayer = Identifiers.machine;
        }

        bool results= UI.WiningStatus(grid);
        while (!results)
        {
            if (nextPlayer == Identifiers.human)
            {
                UI.UserRowAndColumnInput(grid);
                nextPlayer = Identifiers.machine;
                UI.WiningStatus(grid);
                if (UI.WiningStatus(grid)==true)
                {
                    break;
                }
            }
            else
            {
                UI.AiMove(grid);
                nextPlayer = Identifiers.human;
                UI.WiningStatus(grid);
                if (UI.WiningStatus(grid)==true)
                {
                    break;
                }
            }

            UI.DisplayingWholeGrid(grid);

            bool fullGrid = Logic.GridIsFull(grid);
            if (fullGrid)
            {
                Console.WriteLine("The grid is full, and the result is...");
                Console.WriteLine("It is a tie");  
                break;
            }
        }

        Console.WriteLine("Thank you for playing");

    }
}

