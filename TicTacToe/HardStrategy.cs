using System;
using My.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HardStrategy : IComputerDifficulty
    {
        public int Score(string[] spaces)
        {
            return Rules.Won(spaces) ? 10 : 0;
        }

        public int MaxScore(int bestValue, int value)
        {
            return bestValue > value ? bestValue : value;
        }

        public string[] UpdateSpaces(int index, string[] spaces, string marker)
        {
            spaces[index] = marker;
            return spaces;
        }

        public List<string[]> FindChildren(string[] spaces, string marker)
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

        public int Minimax(string[] spaces, string marker, int depth, bool maximizingPlayer, int minValue = 1000, int maxValue = -1000)
        {
            if (Rules.Over(spaces) || depth > 8)
            {
                int score = Score(spaces) * depth;
                return maximizingPlayer ? score : score * -1;
            }

            maximizingPlayer = !maximizingPlayer;
            string oppositeMarker = Helper.OppositeMarker(marker);
            List<string[]> children = FindChildren(spaces, oppositeMarker);

            if (maximizingPlayer)
            {
                foreach (string[] child in children)
                {
                    maxValue = Math.Max(maxValue, Minimax(child, oppositeMarker, depth - 1, true, minValue, maxValue));
                }

                return maxValue;
            }
            else
            {
                foreach (string[] child in children)
                {
                    minValue = Math.Min(minValue, Minimax(child, oppositeMarker, depth - 1, false, minValue, maxValue));
                }

                return minValue;
            }
        }

        public Dictionary<int, int> ScoresByMove(string[] spaces, string marker)
        {
            Dictionary<int, int> ScoresByMove = new Dictionary<int, int>();
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);
            List<string[]> children = FindChildren(spaces, marker);
            int index = 0;

            foreach(string space in availableSpaces)
            {
                int depth = availableSpaces.Count();
                int move = Int32.Parse(space);
                int score = Minimax(children[index], marker, depth, true);
                ScoresByMove.Add(move, score);
                index += 1;
            }

            return ScoresByMove;
        }

        public int BestMove(string[] spaces, string marker)
        {
            Dictionary<int, int> scoresByMove = ScoresByMove(spaces, marker);
            KeyValuePair<int, int> highestScoreByMove = scoresByMove.Aggregate((left, right) => left.Value > right.Value ? left : right);
            return highestScoreByMove.Key;

        }
    }
}
