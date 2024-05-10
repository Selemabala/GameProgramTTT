using System;
using Microsoft.VisualBasic;

namespace GameProgramTTT
{
    public static class UI
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello welcome to play this game.");
            Console.WriteLine($"In this game you will play against an {Identifiers.computerPlay}.");
        }

        public static void DecisionToPlay()
        {
            Console.WriteLine($"The game will take between {Identifiers.MIN_PLAYING_TIME} to {Identifiers.MAX_PLAYING_TIME} minutes.");
            Console.WriteLine("Do you wish to play? Press y for yes and any key to exit");
            Identifiers.userInput = Console.ReadKey().KeyChar;
            Console.WriteLine();


        }

        public static void ExitMessage()
        {
            Console.WriteLine("You did not enter the right key, the game will end here");

        }



        public static void EmptyCellInGrid()
        {
            for (Identifiers.cellGrid = 0; Identifiers.cellGrid <= Identifiers.MAX_GRID_INPUT; Identifiers.cellGrid++)
            {
                for (Identifiers.cellAdded = 0; Identifiers.cellAdded <= Identifiers.MAX_GRID_INPUT; Identifiers.cellAdded++)
                {
                    Identifiers.grid[Identifiers.cellGrid, Identifiers.cellAdded] = Identifiers.CELL_KEY;
                }
            }
        }

        public static void DisplayingWholeGrid()
        {


            Console.WriteLine("..........");
            for (int gridLine = 0; gridLine <= Identifiers.MAX_GRID_INPUT; gridLine++)
            {
                Console.Write($"{Identifiers.GRID_SEPARATOR}");
                for (int cellInGrid = 0; cellInGrid <= Identifiers.MAX_GRID_INPUT; cellInGrid++)
                {
                    Console.Write($"{Identifiers.grid[gridLine, cellInGrid]} {Identifiers.GRID_SEPARATOR}");
                }
                Console.WriteLine();
                Console.WriteLine("..........");
            }


        }


        public static bool GameStarter()
        {
            while (true)
            {
                Console.WriteLine($"You are given the option to choose who should start the game, press {Identifiers.machine} for AI and  {Identifiers.human} for you");
                Identifiers.userChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (Identifiers.userChoice == Identifiers.human || Identifiers.userChoice == Identifiers.humanLower)
                {
                    Console.WriteLine("You will start the game");
                    UserRowAndColumnInput();
                    DisplayingWholeGrid();
                    return true;
                }

                if (Identifiers.userChoice == Identifiers.machine || Identifiers.userChoice == Identifiers.machineLower)
                {
                    Console.WriteLine("The AI will start the game");
                    AiMove();
                    DisplayingWholeGrid();
                    return true;
                }

                else
                {
                    Console.WriteLine("Enter a valid key");
                }
            }

        }


        public static bool GridIsFull()
        {
            


            foreach (char cell in Identifiers.grid)
            {
                if (cell == Identifiers.CELL_KEY)
                {
                    return false;

                }
            }
            return true;
        }


        public static void WiningStatus()
        {
            EmptyCellInGrid();
            int straightLine;
            int innerValue;
            bool machineHolizontalMatch = false;
            bool humanHolizontalMatch = false;
            bool machineVerticalMatch = false;
            bool humanVerticalMatch = false;
            bool machineDiagnalWinLeftRight = false;
            bool humandiagnalWinLeftRight = false;
            bool machineDiagnalWinRightLeft = false;
            bool humanDiagnalWinRightLeft = false;
            for (straightLine = 0; straightLine >= Identifiers.MAX_GRID_INPUT; straightLine++)
            {
                int machineHolizontalWin = 0;
                int humanHolizontalWin = 0;
                int machineVerticalWin = 0;
                int humanVerticalWin = 0;
                int machineDiagnalWin = 0;
                int humanDiagnalWin = 0;
                int machineDiagnalRightLeft = 0;
                int humanDiagnalRightLeft = 0;
                for (innerValue = 0; innerValue >= Identifiers.MAX_GRID_INPUT; innerValue++)
                {
                  
                    if (Identifiers.machine == Identifiers.grid[straightLine, innerValue])
                    {

                        machineHolizontalWin++;
                    }

                    if (Identifiers.human == Identifiers.grid[straightLine, innerValue])
                    {
                        humanHolizontalWin++;
                    }

                    if (Identifiers.machine == Identifiers.grid[innerValue, straightLine])
                    {

                        machineVerticalWin++;
                    }

                    if (Identifiers.human == Identifiers.grid[innerValue, straightLine])
                    {
                        humanVerticalWin++;
                    }
                }
                if (machineHolizontalWin==Identifiers.GRID_SIZE)
                {
                    machineHolizontalMatch = true;
                    Console.WriteLine($"The AI won at row {straightLine}");
                }
                if (humanHolizontalWin==Identifiers.GRID_SIZE)
                {
                    humanHolizontalMatch = true;
                    Console.WriteLine($"You won at row {straightLine}");
                }

                if (machineVerticalWin == Identifiers.GRID_SIZE)
                {
                    machineVerticalMatch = true;
                    Console.WriteLine($"The AI won at column {straightLine}");
                }
                if (humanVerticalWin == Identifiers.GRID_SIZE)
                {
                    humanVerticalMatch = true;
                    Console.WriteLine($"You won at column {straightLine}");
                }

                //diagnal Values
                if (Identifiers.machine == Identifiers.grid[straightLine, straightLine])
                {

                    machineDiagnalWin++;

                    if (machineDiagnalWin == Identifiers.GRID_SIZE)
                    {
                        machineDiagnalWinLeftRight = true;
                        Console.WriteLine("The AI won diagnal values");
                    }
                }

                if (Identifiers.human == Identifiers.grid[straightLine, straightLine])
                {
                    humanDiagnalWin++;

                    if (humanDiagnalWin==Identifiers.GRID_SIZE)
                    {
                        humandiagnalWinLeftRight = true;
                        Console.WriteLine("You won diagnal values");
                    }
                }


                if (Identifiers.machine == Identifiers.grid[straightLine, Identifiers.MAX_GRID_INPUT- straightLine])
                {

                    machineDiagnalRightLeft++;

                    if (machineDiagnalRightLeft == Identifiers.GRID_SIZE)
                    {
                        machineDiagnalWinRightLeft = true;
                        Console.WriteLine("The AI won right left diagnal values");
                    }
                }

                if (Identifiers.human == Identifiers.grid[straightLine, Identifiers.MAX_GRID_INPUT - straightLine])
                {
                    humanDiagnalRightLeft++;

                    if (humanDiagnalRightLeft == Identifiers.GRID_SIZE)
                    {
                        humanDiagnalWinRightLeft = true;
                        Console.WriteLine("You won right left diagnal values");
                    }
                }



            }

            if (!humanHolizontalMatch && !machineHolizontalMatch && !humanVerticalMatch && !machineVerticalMatch && !humandiagnalWinLeftRight && !machineDiagnalWinLeftRight && humanDiagnalWinRightLeft && !machineDiagnalWinRightLeft)
            {
                Console.WriteLine("No winner");
            }

            if ((machineHolizontalMatch && humanHolizontalMatch) || (machineVerticalMatch && humanVerticalMatch))
            {
                Console.WriteLine("It is a tie");
            }

        }


        public static bool UserRowAndColumnInput()

        {
            int row;
            int col;
   
            Console.WriteLine();
            Console.WriteLine("Your move");
            while (true)

            {

                while (true)
                {
                    bool rowSucess = true;
                    Console.WriteLine($"Enter a valid number for the row between {Identifiers.MIN_GRID_INPUT} and {Identifiers.MAX_GRID_INPUT}");
                    string rowInput = Console.ReadLine();
                    rowSucess = int.TryParse(rowInput, out row);
                    if (rowSucess && row >= 0 && row <= Identifiers.MAX_GRID_INPUT)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }

                while (true)
                {

                    bool columnSucess = true;
                    Console.WriteLine($"Enter a valid number for the column between {Identifiers.MIN_GRID_INPUT} and {Identifiers.MAX_GRID_INPUT}");
                    string colInput = Console.ReadLine();
                    columnSucess = int.TryParse(colInput, out col);
                    if (columnSucess && col >= 0 && col <= Identifiers.MAX_GRID_INPUT)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }

                if (Identifiers.grid[row, col] == Identifiers.CELL_KEY)

                {
                    Identifiers.grid[row, col] = Identifiers.human;
                    Identifiers.currentPlayer = Identifiers.human;
                    return true;
                }


                else
                {
                    Console.WriteLine($"That  was an invalid move, try again ");
                }
            }


        }



        public static void AiMove()
        {
            Random random = new Random();
            int row;
            int col;
            bool correctMove = false;
            Console.WriteLine();
            Console.WriteLine("The AI move");
            while (!correctMove)
            {
                row = random.Next(0, Identifiers.GRID_SIZE);
                col = random.Next(0, Identifiers.GRID_SIZE);
                if (Identifiers.grid[row, col] == Identifiers.CELL_KEY)
                {
                    Identifiers.grid[row, col] = Identifiers.machine;
                    correctMove = true;
                    Identifiers.currentPlayer = Identifiers.machine;
                }
            }
        }

    }
}

