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



        public static char[,] CreateEmptyGrid()
        {
            char[,] grid = new char[3, 3];
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

