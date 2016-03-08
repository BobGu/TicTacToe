using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Validator
    {
        public static bool Marker(string marker)
        {
            marker = marker.ToUpper();
            return marker == GlobalConstants.XMarker || marker == GlobalConstants.OMarker;
        }

        public static bool TurnOrder(string turnOrder)
        {
            return turnOrder == "1" || turnOrder == "2";
        }

        public static bool Move(int move, string[] spaces)
        {
            bool inBoundsMove = move < spaces.Length && move >=  0;
            return inBoundsMove && !BoardEvaluator.IsNotAnEmptySpace(spaces[move]);
        }

        public static bool GameMode(string gameMode)
        {
            gameMode = gameMode.ToUpper();
            return gameMode == GlobalConstants.HumanVsComputer || gameMode == GlobalConstants.HumanVsHuman;
        }

        public static bool DifficultyLevel(string difficulty)
        {
            difficulty = difficulty.ToUpper();
            return difficulty == GlobalConstants.EasyDifficulty || difficulty == GlobalConstants.HardDifficulty;
        }

    }
}
