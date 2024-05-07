using System;

namespace GameProgramTTT;

class Program
{
    static void Main(string[] args)
    {
        UI.WelcomeMessage();

        UI.DecisionToPlay();

        Logic.UserDecisionToPlay();

        UI.EmptyCellInGrid();

        UI.DisplayingWholeGrid();

        UI.GameStarter();

        Logic.PlayingLoop();

        Logic.LastResults();

    }
}

