using System;
using GameProgramTTT;
using Microsoft.VisualBasic;

namespace GameProgramTTT
{
    public static class UI
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine(Logic.WelcomeWord());
            Console.WriteLine($"In this game you will play against an {Identifiers.computerPlay}.");
        }


        public static char userInput()
        {
            char userInput = Logic.UserAnswer("Do you wish to play? Press y for yes and any key to exit");
            Console.WriteLine();
            return userInput;
        }


    


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

       





        public static void WiningStatus(Char[,] grid)
        {
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
                    machineHolizontalMatch = true;
                    Console.WriteLine($"The AI won at row {straightLine}");
                }
                if (humanHolizontalWin == Identifiers.GRID_SIZE)
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
                if (Identifiers.machine == grid[straightLine, straightLine])
                {

                    machineDiagnalWin++;

                    if (machineDiagnalWin == Identifiers.GRID_SIZE)
                    {
                        machineDiagnalWinLeftRight = true;
                        Console.WriteLine("The AI won diagnal values");
                    }
                }

                if (Identifiers.human == grid[straightLine, straightLine])
                {
                    humanDiagnalWin++;

                    if (humanDiagnalWin == Identifiers.GRID_SIZE)
                    {
                        humandiagnalWinLeftRight = true;
                        Console.WriteLine("You won diagnal values");
                    }
                }


                if (Identifiers.machine == grid[straightLine, Identifiers.MAX_GRID_INPUT - straightLine])
                {

                    machineDiagnalRightLeft++;

                    if (machineDiagnalRightLeft == Identifiers.GRID_SIZE)
                    {
                        machineDiagnalWinRightLeft = true;
                        Console.WriteLine("The AI won right left diagnal values");
                    }
                }

                if (Identifiers.human == grid[straightLine, Identifiers.MAX_GRID_INPUT - straightLine])
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
                
                    gridValue[row, col]=Identifiers.human;
                    return;
                }


                else
                {
                    Console.WriteLine($"That  was an invalid move, try again ");
                }
            }


        }



        public static void AiMove(Char[,]aivalues)
        {
            Random random = new Random();
            int row=0;
            int col=0;
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



