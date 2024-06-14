using System;

namespace GameProgramTTT;

class Program
{
    static void Main(string[] args)
    {
        char nextPlayer;
        char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];

        UI.ShowWelcomeMessage();
        char userInput = UI.GetuserInput();

        if (userInput == Identifiers.USER_LOWER_KEY)
        {

            Console.WriteLine("Lets go on");
        }
        else
        {

            UI.InformGameEnding();
            return;
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
                Logic.RevealHolizontalOrVerticalWins(grid);
                if (Logic.RevealHolizontalOrVerticalWins(grid))
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
                Logic.RevealHolizontalOrVerticalWins(grid);
                if (Logic.RevealHolizontalOrVerticalWins(grid))
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

