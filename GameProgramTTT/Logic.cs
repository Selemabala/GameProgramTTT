using System;
namespace GameProgramTTT
{
    public static class Logic
    {
        /// <summary>
        /// A method which just returns a statement for welcoming the user 
        /// </summary>
        /// <returns>The welcome statement</returns>
        public static string ShowWelcomeWord()
        {
            string john = "Hello welcome to play this game.";
            return john;
        }

        /// <summary>
        /// This method gets userinputer from the keyboard
        /// </summary>
        /// <param name="question">The question or statement to get a user input character</param>
        /// <returns>The character needed from the Question</returns>
        public static char GetUserAnswer(string question)
        {
            Console.WriteLine(question);
            char userInput = Console.ReadKey().KeyChar;
            return userInput;

        }

        /// <summary>
        /// A method which creates an empty Grid of 3 x 3
        /// </summary>
        /// <returns> the 3x3 grid</returns>
        public static char[,] CreateEmptyGrid()
        {
            char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];
            int cellGrid = 0;
            int cellAdded = 0;
            for (cellGrid = 0; cellGrid <= Identifiers.MAX_GRID_INPUT; cellGrid++)
            {
                for (cellAdded = 0; cellAdded <= Identifiers.MAX_GRID_INPUT; cellAdded++)
                {
                    grid[cellGrid, cellAdded] = Identifiers.CELL_KEY;
                }
            }

            return grid;
        }

        /// <summary>
        /// This method is specifically for displaying the winner. The loop will run and if characters appear 3 times  straight then the method returns true.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>It return boolean true or false. If there is a winner it return true and if there no winner it return false.  </returns>
        public static bool RevealHolizontalWins(Char[,] grid)
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
                    return true;
                }
                if (humanHolizontalWin == Identifiers.GRID_SIZE)
                {
                    return true;
                }

                if (machineVerticalWin == Identifiers.GRID_SIZE)
                {
                    return true;
                }
                if (humanVerticalWin == Identifiers.GRID_SIZE)
                {
                    return true;
                }

            }
            return false;
        }


        /// <summary>
        /// The loop will run and if same characters appear 3 times  straight then the method returns true.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static bool WiningStatusDiagnalValues(Char[,] grid)
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
                        return true;
                    }
                }

                if (Identifiers.HUMAN == grid[i, i])
                {
                    HumanMatchingDiagnal++;

                    if (HumanMatchingDiagnal == Identifiers.GRID_SIZE)
                    {
                        return true;
                    }
                }

                if (Identifiers.MACHINE == grid[i, Identifiers.MAX_GRID_INPUT - i])
                {

                    AiMatchingFromRight++;

                    if (AiMatchingFromRight == Identifiers.GRID_SIZE)
                    {
                        return true;
                    }
                }

                if (Identifiers.HUMAN == grid[i, Identifiers.MAX_GRID_INPUT - i])
                {
                    HumanMatchingFromRight++;

                    if (HumanMatchingFromRight == Identifiers.GRID_SIZE)
                    {
                        return true;
                    }
                }

            }
            return false;
        }


        /// <summary>
        /// This method checks if the grid is full or not. If the grid is not full and no winner then the game will keep on being played
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>it returns a boolen true for a full grid or false if there are still spaces in the grid</returns>
        public static bool DisplayGridIsFull(char[,] grid)
        {
            foreach (char cell in grid)
            {
                if (cell == Identifiers.CELL_KEY)
                {
                    return false;

                }
            }
            return true;
        }

    }
}

