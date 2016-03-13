using System;
using System.Collections.Generic;
using TicTacToe.Games.RulesAndEvaluator;
using TicTacToe.Games.OppositeMarkers;


namespace TicTacToe.Games.Players.Strategies
{
    public class Minimax
    {

        public static int MinOrMaxScore(string[] spaces, string marker, int depth, bool maximizingPlayer, int originalDepth, int alpha = -1000, int beta = 1000)
        {
            if (Rules.Over(spaces) || originalDepth - depth == 6)
            {
                int score = Score(spaces) * depth;
                return maximizingPlayer ? score : score * -1;
            }

            maximizingPlayer = !maximizingPlayer;
            string oppositeMarker = OppositeMarker.Marker(marker);
            List<string[]> children = FindNextBoards(spaces, oppositeMarker);

            if (maximizingPlayer)
            {
                int value;
                foreach (string[] child in children)
                {
                    if(alpha >= beta)
                    {
                        break;
                    }
                    value = MinOrMaxScore(child, oppositeMarker, depth - 1, true, originalDepth, alpha, beta);
                    alpha = Math.Max(alpha, value);
                }

                return alpha;
            }
            else
            {
                int value;
                foreach (string[] child in children)
                {
                    if(alpha >= beta)
                    {
                        break;
                    }
                    value = MinOrMaxScore(child, oppositeMarker, depth - 1, false, originalDepth, alpha, beta);
                    beta = Math.Min(beta, value);
                }

                return beta;
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
