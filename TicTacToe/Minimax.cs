using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Minimax
    {
        public static int MinOrMaxScore(string[] spaces, string marker, int depth, bool maximizingPlayer, int minValue = 1000, int maxValue = -1000)
        {
            if (Rules.Over(spaces) || depth > 8)
            {
                int score = Score(spaces) * depth;
                return maximizingPlayer ? score : score * -1;
            }

            maximizingPlayer = !maximizingPlayer;
            string oppositeMarker = Helper.OppositeMarker(marker);
            List<string[]> children = FindNextBoards(spaces, oppositeMarker);

            if (maximizingPlayer)
            {
                foreach (string[] child in children)
                {
                    maxValue = Math.Max(maxValue, MinOrMaxScore(child, oppositeMarker, depth - 1, true, minValue, maxValue));
                }

                return maxValue;
            }
            else
            {
                foreach (string[] child in children)
                {
                    minValue = Math.Min(minValue, MinOrMaxScore(child, oppositeMarker, depth - 1, false, minValue, maxValue));
                }

                return minValue;
            }
        }

        public static List<string[]> FindNextBoards(string[] spaces, string marker)
        {
            List<string[]> children = new List<string[]>();
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);

            foreach (string space in availableSpaces)
            {
                string[] child = (string[])spaces.Clone();
                int index = Int32.Parse(space);
                child[index] = marker;
                children.Add(child);
            }

            return children;

        }

        private static int Score(string[] spaces)
        {
            return Rules.Won(spaces) ? 10 : 0;
        }

    }
}
