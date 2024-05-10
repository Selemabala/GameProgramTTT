using System;
namespace GameProgramTTT
{
	public static class Identifiers
	{
		public const int MAX_GRID_INPUT = 2;
        public  const int MIN_GRID_INPUT = 0;
        public const int SECOND_GRID_INPUT = 1;
        public  static string computerPlay = "AI";
        public  static string humanPlayer = "You";
        public static char currentPlayer;
        public  const int MIN_PLAYING_TIME = 2;
        public  const int MAX_PLAYING_TIME = 5;
        public  const int GRID_SIZE = 3;
        public static char userLowKey = 'y';
        public static char userUpperKey = 'Y';
        public static char machine = 'A';
        public static char machineLower = 'a';
        public static char human = 'H';
        public static char humanLower = 'h';
        public static char CELL_KEY = '*';
        public static char GRID_SEPARATOR = '|';
        public static char userInput;
        public static int  cellAdded;
        public static int  cellGrid;
        public static char userChoice;
        public static char[,] grid = new char[3,3];

    }
}

