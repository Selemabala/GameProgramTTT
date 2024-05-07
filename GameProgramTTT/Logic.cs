using System;
namespace GameProgramTTT
{
	public static class Logic
	{
		public static bool UserDecisionToPlay()
		{
			if (Identifiers.userInput == Identifiers.userLowKey || Identifiers.userInput == Identifiers.userUpperKey)
			{
				Console.WriteLine("Okay, lets go on");
				return true;
			}
			else
			{
				UI.ExitMessage();
				Environment.Exit(0);
				return false;
			}
	
		}

		public static void PlayingLoop()
		{
			while(!UI.GridIsFull())
			{
				if(Identifiers.currentPlayer== Identifiers.human)
				{
					UI.AiMove();
				}
				else
				{
					UI.UserRowAndColumnInput();
				}

				UI.DisplayingWholeGrid();
			}
		}


		public static void LastResults()
		{
			if (UI.GridIsFull())
			{
				UI.WiningStatus();
			}
		}
		
    }
}

