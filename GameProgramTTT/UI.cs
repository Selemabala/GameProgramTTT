using System;
using GameProgramTTT;
using Microsoft.VisualBasic;

namespace GameProgramTTT
{
    public static class UI
    {
        /// <summary>
        /// This medthod creates and displays a welcome method for the user
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine(Logic.WelcomeWord());
            Console.WriteLine($"In this game you will play against an {Identifiers.computerPlay}.");
        }

        /// <summary>
        /// This method is for getting a userinput if the user wants to play or not
        /// </summary>
        /// <returns>The return is the character y for continuing to play or another character to exit</returns>
        public static char userInput()
        {
            char userInput = Logic.UserAnswer("Do you wish to play? Press y for yes and any key to exit");
            Console.WriteLine();
            return userInput;
        }

        /// <summary>
        /// This method adds some lines and dots to make the grid well displayable
        /// </summary>
        /// <param name="john">the parameter is the 3x3 grid</param>
        public static void DisplayingWholeGrid(char[,] john)
        {
            Console.WriteLine("..........");
            for (int gridLine = 0; gridLine <= Identifiers.MAX_GRID_INPUT; gridLine++)
            {
                Console.Write($"{Identifiers.GRID_SEPARATOR}");
                for (int cellInGrid = 0; cellInGrid <= Identifiers.MAX_GRID_INPUT; cellInGrid++)
                {
                    Console.Write($"{john[gridLine, cellInGrid]} {Identifiers.GRID_SEPARATOR}");
                }
                Console.WriteLine();
                Console.WriteLine("..........");
            }

        }

        public static void AiStarting()
        {
            Console.WriteLine("The AI will start the game");
        }

        public static void HumanStarting()
        {
            Console.WriteLine("You will start the game");
        }
        /// <summary>
        /// Asks suser who should make the first move
        /// </summary>
        /// <returns>true if AI, false if human</returns>
        public static bool GameStarter()
        {
            while (true)
            {
                char userChoice = Logic.UserAnswer($"You are given the option to choose who should start the game, press {Identifiers.machine} for AI and  {Identifiers.human} for you");
                Console.WriteLine();
                if (userChoice == Identifiers.human || userChoice == Identifiers.humanLower)
                {
                    Console.WriteLine("You will start the game");
                    return false;
                }

                if (userChoice == Identifiers.machine || userChoice == Identifiers.machineLower)
                {
                    Console.WriteLine("The AI will start the game");
                    return true;
                }
                Console.WriteLine("Enter a valid key");
            }

        }

        /// <summary>
        /// This method is specifically for displaying the winner. The loop will run and if characters appear 3 times  straight then the winnner is displayed and the method ends.
        /// </summary>
        /// <param name="grid"> it uses the grid which is created and will be updated in a loop iteration </param>
        public static bool WiningStatus(Char[,] grid)
        {
            int straightLine;
            int innerValue;
            for (straightLine = 0; straightLine <= Identifiers.MAX_GRID_INPUT; straightLine++)
            {
                int machineHolizontalWin = 0;
                int humanHolizontalWin = 0;
                int machineVerticalWin = 0;
                int humanVerticalWin = 0;
                int machineDiagnalWin = 0;
                int humanDiagnalWin = 0;
                int machineDiagnalRightLeft = 0;
                int humanDiagnalRightLeft = 0;
                for (innerValue = 0; innerValue <= Identifiers.MAX_GRID_INPUT; innerValue++)
                {

                    if (Identifiers.machine == grid[straightLine, innerValue])
                    {

                        machineHolizontalWin++;
                    }

                    if (Identifiers.human == grid[straightLine, innerValue])
                    {
                        humanHolizontalWin++;
                    }

                    if (Identifiers.machine == grid[innerValue, straightLine])
                    {

                        machineVerticalWin++;
                    }

                    if (Identifiers.human == grid[innerValue, straightLine])
                    {
                        humanVerticalWin++;
                    }
                }
                if (machineHolizontalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"The AI won at row {straightLine}");
                    return true;
                }
                if (humanHolizontalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"You won at row {straightLine}");
                    return  true;
                   
                }

                if (machineVerticalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"The AI won at column {straightLine}");
                    return true;
                }
                if (humanVerticalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"You won at column {straightLine}");
                    return true;
                }

                //diagnal Values
                if (Identifiers.machine == grid[straightLine, straightLine])
                {

                    machineDiagnalWin++;

                    if (machineDiagnalWin == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("The AI won diagnal values");
                        return true;
                    }
                }

                if (Identifiers.human == grid[straightLine, straightLine])
                {
                    humanDiagnalWin++;

                    if (humanDiagnalWin == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("You won diagnal values");
                        return true;
                    }
                }

                if (Identifiers.machine == grid[straightLine, Identifiers.MAX_GRID_INPUT - straightLine])
                {

                    machineDiagnalRightLeft++;

                    if (machineDiagnalRightLeft == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("The AI won right left diagnal values");
                        return true;
                    }
                }

                if (Identifiers.human == grid[straightLine, Identifiers.MAX_GRID_INPUT - straightLine])
                {
                    humanDiagnalRightLeft++;

                    if (humanDiagnalRightLeft == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("You won right left diagnal values");
                        return true;
                    }
                }
                
            }
            return false;
        }

        /// <summary>
        /// Method to get 2 numbers/coordinates from user where the user wants to place his symbol if the posisiton is valid
        /// </summary>
        /// <param name="gridValue">playing grid to be checked for valid placement</param>
        /// <returns>list of 2 selected numbers</returns>
        public static void UserRowAndColumnInput(char[,] gridValue)
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

                if (gridValue[row, col] == Identifiers.CELL_KEY)

                {
                    gridValue[row, col] = Identifiers.human;
                    return;
                }
                else
                {
                    Console.WriteLine($"That  was an invalid move, try again ");
                }
            }
        }

        public static void AiMove(Char[,] aivalues)
        {
            Random random = new Random();
            int row = 0;
            int col = 0;
            bool correctMove = false;
            Console.WriteLine();
            Console.WriteLine("The AI move");
            while (!correctMove)
            {
                row = random.Next(0, Identifiers.GRID_SIZE);
                col = random.Next(0, Identifiers.GRID_SIZE);
                if (aivalues[row, col] == Identifiers.CELL_KEY)
                {
                    aivalues[row, col] = Identifiers.machine;
                    correctMove = true;
                    return;
                }
            }

        }

    }
}



