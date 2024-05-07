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
			Identifiers.userInput= Console.ReadKey().KeyChar;
            Console.WriteLine();
            

		}

		public static void ExitMessage()
		{
			Console.WriteLine("You did not enter the right key, the game will end here");

        }



        public static char[,] EmptyCellInGrid()
        {
            char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];
            for (Identifiers.cellGrid = 0; Identifiers.cellGrid <= Identifiers.MAX_GRID_INPUT; Identifiers.cellGrid++)
            {
                for (Identifiers.cellAdded = 0; Identifiers.cellAdded <= Identifiers.MAX_GRID_INPUT; Identifiers.cellAdded++)
                {
                    grid[Identifiers.cellGrid, Identifiers.cellAdded] = Identifiers.CELL_KEY;
                }
            }

            return grid;
        }

        public static void DisplayingWholeGrid()
        {

            char[,]grid=EmptyCellInGrid();
            GridHolizontalLine();
            for (int gridLine = 0; gridLine <= Identifiers.MAX_GRID_INPUT; gridLine++)
            {
                LineSepator();
                for (int cellInGrid = 0; cellInGrid <= Identifiers.MAX_GRID_INPUT; cellInGrid++)
                {
                    Console.Write($"{grid[gridLine, cellInGrid]} {Identifiers.GRID_SEPARATOR}");
                }
                GridBottomLine();
            }
         

        }


        public static void GridHolizontalLine()
		{
            Console.WriteLine("..........");
        }

		public static void LineSepator()
		{
            Console.Write($"{Identifiers.GRID_SEPARATOR}");
        }

		public static void GridBottomLine()
		{
            Console.WriteLine();
            Console.WriteLine("..........");
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
            char[,] grid = EmptyCellInGrid();


            foreach (char cell in grid)
            {
                if (cell==Identifiers.CELL_KEY)
                {
                    return false;
                   
                }
            }
            return true;
        }


        public static void WiningStatus()
        {
            char[,] grid = EmptyCellInGrid();
            int straightLine;
            int innerValue;
            bool machineHolizontalWin = false;
            bool humanHolizontalWin = false;
            bool machineDiagnallWinLeftRight = false;
            bool humandiagnalWinLeftRight = false;
            bool machineDiagnallWinRightLeft = false;
            bool humanDiagnalWinRightLeft = false;
            for (straightLine = 0; straightLine >= Identifiers.MAX_GRID_INPUT; straightLine++)
            {
                for (innerValue = 0; innerValue >= Identifiers.MAX_GRID_INPUT; innerValue++) 
                {
                 

                    if (Identifiers.machine == grid[straightLine, innerValue])
                    {
                        Console.WriteLine("The AI won");
                        machineHolizontalWin = true;
                    }

                    if (Identifiers.human == grid[straightLine, innerValue])
                    {
                        Console.WriteLine("You won");
                        humanHolizontalWin = true;
                    }
                }
            }

            if (Identifiers.human == grid[Identifiers.MIN_GRID_INPUT, Identifiers.MIN_GRID_INPUT] && Identifiers.human == grid[Identifiers.SECOND_GRID_INPUT, Identifiers.SECOND_GRID_INPUT] && Identifiers.human == grid[Identifiers.MAX_GRID_INPUT, Identifiers.MAX_GRID_INPUT])
            {
                Console.WriteLine("You won diagnal values");
                humandiagnalWinLeftRight = true;
            }

            if (Identifiers.machine == grid[Identifiers.MIN_GRID_INPUT, Identifiers.MIN_GRID_INPUT] && Identifiers.machine == grid[Identifiers.SECOND_GRID_INPUT, Identifiers.SECOND_GRID_INPUT] && Identifiers.machine == grid[Identifiers.MAX_GRID_INPUT, Identifiers.MAX_GRID_INPUT])
            {
                Console.WriteLine("The AI won diagnal values");
                machineDiagnallWinLeftRight = true;
            }

            if(Identifiers.human==grid[Identifiers.MIN_GRID_INPUT, Identifiers.MAX_GRID_INPUT] && Identifiers.human == grid[Identifiers.SECOND_GRID_INPUT, Identifiers.SECOND_GRID_INPUT] && Identifiers.human == grid[Identifiers.MAX_GRID_INPUT,Identifiers.MIN_GRID_INPUT])
            {
                Console.WriteLine("You won diagnals from right to left");
                humanDiagnalWinRightLeft = true;
            }


            if (Identifiers.machine == grid[Identifiers.MIN_GRID_INPUT, Identifiers.MAX_GRID_INPUT] && Identifiers.machine == grid[Identifiers.SECOND_GRID_INPUT, Identifiers.SECOND_GRID_INPUT] && Identifiers.machine == grid[Identifiers.MAX_GRID_INPUT, Identifiers.MIN_GRID_INPUT])
            {
                Console.WriteLine("The AI won diagnals from right to left");
                machineDiagnallWinRightLeft = true;
            }

            if (!humanHolizontalWin && !machineHolizontalWin && !humandiagnalWinLeftRight && !machineDiagnallWinLeftRight && humanDiagnalWinRightLeft && !machineDiagnallWinRightLeft)
            {
                Console.WriteLine("No winner");
            }

            if (machineHolizontalWin && humanHolizontalWin)
            {
                Console.WriteLine("It is a tie");
            }

        }


        public static  bool UserRowAndColumnInput()
            
		{
            int row;
            int col;
            char[,] grid = EmptyCellInGrid();
            
            Console.WriteLine();
            Console.WriteLine("Your move");
            while (true)
                
            {

                while (true)
                {
                    bool rowSucess = true;
                    Console.WriteLine($"Enter a valid number for the row between {Identifiers.MIN_GRID_INPUT} and {Identifiers.MAX_GRID_INPUT}");
                    string rowInput = Console.ReadLine();
                    rowSucess = int.TryParse(rowInput, out  row);
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
                    columnSucess = int.TryParse(colInput, out  col);
                    if (columnSucess && col >=0 && col <= Identifiers.MAX_GRID_INPUT)
                    {
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }

                if (grid[row, col] == Identifiers.CELL_KEY)
                    
                {     
                    grid[row, col] = Identifiers.human;
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
            char[,] grid = EmptyCellInGrid();
            Console.WriteLine();
            Console.WriteLine("The AI move");
            while (!correctMove)
            {
                row = random.Next(0,Identifiers.GRID_SIZE);
                col = random.Next(0,Identifiers.GRID_SIZE);
                if (grid[row, col] == Identifiers.CELL_KEY)
                {
                    grid[row, col] = Identifiers.machine;
                    correctMove = true;
                    Identifiers.currentPlayer = Identifiers.machine;
                }
            }
        }

  

    }
}

