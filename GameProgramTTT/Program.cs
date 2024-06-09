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
        char userInput = UI.GetuserInput();

        if (userInput == Identifiers.USERLOWERKEY || userInput == Identifiers.USERUPERKEY)
        {

            play = true;
        }
        else
        {

            play = false;
        }

        if (!play)
        {
            UI.InformGameEnding();
            return;
        }
        else
        {
            Console.WriteLine("Lets go on");
        }

        grid = Logic.CreateEmptyGrid();


        UI.DisplayingWholeGrid(grid);


        if (!UI.GetGamePlayer())
        {
            nextPlayer = Identifiers.HUMAN;
        }
        else
        {
            nextPlayer = Identifiers.MACHINE;
        }


        while (true)
        {
            if (nextPlayer == Identifiers.HUMAN)
            {
                UI.HumanPlaying(grid);
                nextPlayer = Identifiers.MACHINE;
                UI.DisplayingWholeGrid(grid);
                Logic.RevealHolizontalWins(grid);
                if (Logic.RevealHolizontalWins(grid))
                {
                    UI.PrintHolizontalWins(grid);
                    break;
                }

                Logic.WiningStatusDiagnalValues(grid);
                if (Logic.WiningStatusDiagnalValues(grid))
                {
                    UI.PrintingResultsDiagnalValues(grid);
                    break;
                }
            }
            else
            {
                UI.AiPlaying(grid);
                nextPlayer = Identifiers.HUMAN;
                UI.DisplayingWholeGrid(grid);
                Logic.RevealHolizontalWins(grid);
                if (Logic.RevealHolizontalWins(grid))
                {
                    UI.PrintHolizontalWins(grid);
                    break;
                }

                Logic.WiningStatusDiagnalValues(grid);
                if (Logic.WiningStatusDiagnalValues(grid))
                {
                    UI.PrintingResultsDiagnalValues(grid);
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

