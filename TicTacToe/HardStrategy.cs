using System;
using My.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HardStrategy
    {
        public static int Score(string[] spaces)
        {
            return Rules.Won(spaces) ? 10 : 0;
        }

        public static int MaxScore(int bestValue, int value)
        {
            return bestValue > value ? bestValue : value;
        }
        public static string OppositeMarker(string marker)
        {
            return marker == "X" ? "O" : "X";
        }

        public static string[] UpdateSpaces(int index, string[] spaces, string marker)
        {
            spaces[index] = marker;
            return spaces;
        }

        public static List<string[]> FindChildren(string[] spaces, string marker)
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

        public static int Minimax(string[] spaces, string marker, int depth, bool maximizingPlayer, int minValue = 1000, int maxValue = -1000)
        {
            if (Rules.Over(spaces))
            {
                if (maximizingPlayer)
                {
                    return Score(spaces) * depth;
                }
                else 
                {
                    return Score(spaces) * -1 * depth;
                }
            }

            maximizingPlayer = !maximizingPlayer;
            string oppositeMarker = OppositeMarker(marker);

            if (maximizingPlayer)
            {
                spaces = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
                List<string[]> children = FindChildren(spaces, oppositeMarker);
                foreach (string[] child in children)
                {
                    maxValue = Math.Max(maxValue, Minimax(child, oppositeMarker, depth - 1, true, minValue, maxValue));
                }

                return maxValue;
            }

            else
            {
                List<string[]> children = FindChildren(spaces, oppositeMarker);
                foreach (string[] child in children)
                {
                    minValue = Math.Min(minValue, Minimax(child, oppositeMarker, depth - 1, false, minValue, maxValue));
                }

                return minValue;
            }



        }

        public static int BestMove(string[] spaces, string marker)
        {
            Dictionary<int, int> moveScores = new Dictionary<int, int>();
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);
            foreach (string space in availableSpaces)
            {
                int index = Int32.Parse(space);
                spaces[index] = marker;
                int score = Minimax(spaces, marker, availableSpaces.Length, true);
                moveScores.Add(index, score);
            }
            Console.WriteLine(moveScores.Values.Min());
            KeyValuePair<int, int> bestMoveScore = moveScores.Aggregate((left, right) => left.Value >= right.Value ? left : right);
            return bestMoveScore.Key;
        }
    }
}
