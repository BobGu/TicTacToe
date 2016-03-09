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

        public static bool GameMode(string gameMode)
        {
            gameMode = gameMode.ToUpper();
            return gameMode == GlobalConstants.HumanVsComputer || gameMode == GlobalConstants.HumanVsHuman;
        }

        public static bool StrategyLevel(string strategy)
        {
            strategy = strategy.ToUpper();
            return strategy == GlobalConstants.EasyStrategy || strategy == GlobalConstants.HardStrategy;
        }

        public static bool Move(string move, string[] spaces)
        {
            int index;
            bool isANumber = Int32.TryParse(move, out index);
            return isANumber ? MoveIsInboundsAndSpaceIsEmpty(index, spaces) : false;
        }

        private static bool MoveIsInboundsAndSpaceIsEmpty(int index, string[] spaces)
        {
            return InBoundsMove(index, spaces.Length) && !BoardEvaluator.IsNotAnEmptySpace(spaces[index]);
        }

        private static bool InBoundsMove(int index, int spacesLength)
        {
            return index < spacesLength && index >= 0;
        }
    }
}
