using System;
using TicTacToe.Games.RulesAndEvaluator;
using TicTacToe.GlobalConstants;

namespace TicTacToe.Games.IOValidator
{
    public class Validator
    {
        public static bool Marker(string marker)
        {
            marker = marker.ToUpper();
            return marker == GlobalConstant.XMarker || marker == GlobalConstant.OMarker;
        }

        public static bool TurnOrder(string turnOrder)
        {
            return turnOrder == "1" || turnOrder == "2";
        }

        public static bool GameMode(string gameMode)
        {
            gameMode = gameMode.ToUpper();
            return gameMode == GlobalConstant.HumanVsComputer || gameMode == GlobalConstant.HumanVsHuman;
        }

        public static bool StrategyLevel(string strategy)
        {
            strategy = strategy.ToUpper();
            return strategy == GlobalConstant.EasyStrategy || strategy == GlobalConstant.HardStrategy;
        }

        public static bool Move(string move, string[] spaces)
        {
            int index;
            bool isANumber = Int32.TryParse(move, out index);
            return isANumber ? MoveIsInboundsAndSpaceIsEmpty(index, spaces) : false;
        }

        public static bool BoardDimmensions(string dimmension)
        {
            return dimmension == "3" || dimmension == "4";
        }

        private static bool MoveIsInboundsAndSpaceIsEmpty(int index, string[] spaces)
        {
            return InBoundsMove(index, spaces.Length) && BoardEvaluator.IsAnEmptySpace(spaces[index]);
        }

        private static bool InBoundsMove(int index, int spacesLength)
        {
            return index < spacesLength && index >= 0;
        }
    }
}
