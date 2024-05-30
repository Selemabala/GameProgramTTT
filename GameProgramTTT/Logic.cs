using System;
namespace GameProgramTTT
{
    public static class Logic
    {
        /// <summary>
        /// A method which just returns a statement for welcoming the user 
        /// </summary>
        /// <returns>The welcome statement</returns>
        public static string WelcomeWord()
        {
            string john = "Hello welcome to play this game.";
            return john;
        }

        /// <summary>
        /// This method gets userinputer from the keyboard
        /// </summary>
        /// <param name="question">The question or statement to get a user input character</param>
        /// <returns>The character needed from the Question</returns>
        public static char UserAnswer(string question)
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
        /// This method checks if the grid is full or not. If the grid is not full and no winner then the game will keep on being played
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>it returns a boolen true for a full grid or false if there are still spaces in the grid</returns>
        public static bool GridIsFull(char[,] grid)
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

