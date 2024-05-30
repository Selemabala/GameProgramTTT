using System;

namespace GameProgramTTT;

class Program
{
    static void Main(string[] args)
    {
        char nextPlayer;
        char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];
        bool play = false; ;

        UI.WelcomeMessage();
        UI.Gametime();
        char userInput = UI.userInput();

        if (userInput == Identifiers.USERLOWERKEY || userInput == Identifiers.USERUPERKEY)
        {

            play = true;
        }
        else
        {

            play = false;
        }

        bool continuePlaying;
        continuePlaying = play;

        if (!continuePlaying)
        {
            UI.GameEnd();
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
            nextPlayer = Identifiers.HUMAN;
        }
        else
        {
            nextPlayer = Identifiers.MACHINE;
        }

        bool results = UI.WiningStatus(grid);
        while (!results)
        {
            if (nextPlayer == Identifiers.HUMAN)
            {
                UI.UserRowAndColumnInput(grid);
                nextPlayer = Identifiers.MACHINE;
                UI.WiningStatus(grid);
                UI.DisplayingWholeGrid(grid);
                if (UI.WiningStatus(grid))
                {
                    break;
                }
            }
            else
            {
                UI.AiMove(grid);
                nextPlayer = Identifiers.HUMAN;
                UI.WiningStatus(grid);
                UI.DisplayingWholeGrid(grid);
                if (UI.WiningStatus(grid))
                {
                    break;
                }
            }

            bool fullGrid = Logic.GridIsFull(grid);
            if (fullGrid)
            {
                UI.NoWinnerResults();
                break;
            }
        }

        UI.GameLastStatement();

    }
}

