using System;

namespace GameProgramTTT;

class Program
{
    static void Main(string[] args)
    {
        char nextPlayer;
        char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];
        bool play = false; ;

        UI.ShowWelcomeMessage();
        UI.DisplayGametime();
        char userInput = UI.GetuserInput();

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
            UI.InformGameEnding();
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Lets go on");
        }

        grid = Logic.CreateEmptyGrid();


        UI.DisplayingWholeGrid(grid);


        bool AIisStarting = UI.GetGameStarter();

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
                UI.HumanPlaying(grid);
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
                UI.AiPlaying(grid);
                nextPlayer = Identifiers.HUMAN;
                UI.WiningStatus(grid);
                UI.DisplayingWholeGrid(grid);
                if (UI.WiningStatus(grid))
                {
                    break;
                }
            }

            bool fullGrid = Logic.DisplayGridIsFull(grid);
            if (fullGrid)
            {
                UI.ShowTieResults();
                break;
            }
        }

        UI.DisplayLastThanksStatement();

    }
}

