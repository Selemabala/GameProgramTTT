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
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Hello welcome to play this game.");
            Console.WriteLine($"In this game you will play against an {Identifiers.COMPUTER_PLAY}.");
        }

        /// <summary>
        /// This method is for getting a userinput if the user wants to play or not
        /// </summary>
        /// <returns>The return is the character y for continuing to play or another character to exit</returns>
        public static char GetuserInput()
        {
            char userInput = Logic.GetUserAnswer("Do you wish to play? Press y for yes and any key to exit");
            Console.WriteLine();
            return userInput;
        }

        /// <summary>
        /// A statement to inform the user that the game ends now
        /// </summary>
        public static void InformGameEnding()
        {
            Console.WriteLine("The game will end here");
        }

        /// <summary>
        /// A statement to inform the user that the game is full and there is no winner
        /// </summary>
        public static void ShowTieResults()
        {
            Console.WriteLine("The grid is full, and the result is...");
            Console.WriteLine("It is a tie");
        }

        /// <summary>
        /// A statement to inform the user that the game ends now and thanks for playig
        /// </summary>
        public static void DisplayLastThanksStatement()
        {
            Console.WriteLine("Thank you for playing");
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

        /// <summary>
        /// Asks suser who should make the first move
        /// </summary>
        /// <returns>true if AI, false if human</returns>
        public static bool GetGamePlayer()
        {
            while (true)
            {
                char userChoice = Logic.GetUserAnswer($"You are given the option to choose who should start the game, press {Identifiers.MACHINE} for AI and  {Identifiers.HUMAN} for you");
                Console.WriteLine();
                if (userChoice == Identifiers.HUMAN || userChoice == Identifiers.HUMANLOWER)
                {
                    Console.WriteLine("You will start the game");
                    return false;
                }

                if (userChoice == Identifiers.MACHINE || userChoice == Identifiers.MACHINELOWER)
                {
                    Console.WriteLine("The AI will start the game");
                    return true;
                }
                Console.WriteLine("Enter a valid key");
            }

        }

        /// <summary>
        /// The method prints the statement where there is a winner
        /// </summary>
        /// <param name="grid"></param>
        public static void PrintHolizontalWins(Char[,] grid)
        {
            int i;
            int j;
            for (i = 0; i <= Identifiers.MAX_GRID_INPUT; i++)
            {
                int machineHolizontalWin = 0;
                int humanHolizontalWin = 0;
                int machineVerticalWin = 0;
                int humanVerticalWin = 0;
                for (j = 0; j <= Identifiers.MAX_GRID_INPUT; j++)
                {

                    if (Identifiers.MACHINE == grid[i, j])
                    {

                        machineHolizontalWin++;
                    }

                    if (Identifiers.HUMAN == grid[i, j])
                    {
                        humanHolizontalWin++;
                    }

                    if (Identifiers.MACHINE == grid[j, i])
                    {

                        machineVerticalWin++;
                    }

                    if (Identifiers.HUMAN == grid[j, i])
                    {
                        humanVerticalWin++;
                    }
                }


                if (machineHolizontalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"The AI won at row {i}");
                    return;
                }
                if (humanHolizontalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"You won at row {i}");
                    return;
                }

                if (machineVerticalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"The AI won at column {i}");
                    return;
                }
                if (humanVerticalWin == Identifiers.GRID_SIZE)
                {
                    Console.WriteLine($"You won at column {i}");
                    return;
                }
            }
        }


        /// <summary>
        /// This method prints the results where there is a winning
        /// </summary>
        /// <param name="grid"></param>
        public static void PrintingResultsDiagnalValues(Char[,] grid)
        {
            int i;
            int AiMatchingDiagnal = 0;
            int HumanMatchingDiagnal = 0;
            int AiMatchingFromRight = 0;
            int HumanMatchingFromRight = 0;
            for (i = 0; i <= Identifiers.MAX_GRID_INPUT; i++)
            {
                if (Identifiers.MACHINE == grid[i, i])
                {

                    AiMatchingDiagnal++;

                    if (AiMatchingDiagnal == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("The AI won diagnal values");
                    }
                }

                if (Identifiers.HUMAN == grid[i, i])
                {
                    HumanMatchingDiagnal++;

                    if (HumanMatchingDiagnal == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("You won diagnal values");
                    }
                }

                if (Identifiers.MACHINE == grid[i, Identifiers.MAX_GRID_INPUT - i])
                {

                    AiMatchingFromRight++;

                    if (AiMatchingFromRight == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("The AI won right left diagnal values");
                    }
                }

                if (Identifiers.HUMAN == grid[i, Identifiers.MAX_GRID_INPUT - i])
                {
                    HumanMatchingFromRight++;

                    if (HumanMatchingFromRight == Identifiers.GRID_SIZE)
                    {
                        Console.WriteLine("You won right left diagnal values");
                    }
                }

            }
        }

        /// <summary>
        /// Method to get 2 numbers/coordinates from user where the user wants to place his symbol if the posisiton is valid
        /// </summary>
        /// <param name="gridValue">playing grid to be checked for valid placement</param>
        /// <returns>list of 2 selected numbers</returns>
        public static void HumanPlaying(char[,] gridValue)
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
                    gridValue[row, col] = Identifiers.HUMAN;
                    return;
                }
                else
                {
                    Console.WriteLine($"That  was an invalid move, try again ");
                }
            }
        }

        /// <summary>
        /// The AI will check where there is empty space and place the A letter
        /// </summary>
        /// <param name="aivalues"> this will be the existing grid</param>
        public static void AiPlaying(Char[,] aivalues)
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
                    aivalues[row, col] = Identifiers.MACHINE;
                    correctMove = true;
                    return;
                }
            }

        }

    }
}



