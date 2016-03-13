using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Games.RulesAndEvaluator;

namespace TicTacToe.Games.Players.Strategies
{
    public class HardStrategy : IComputerStrategy
    {

        public int BestMove(string[] spaces, string marker)
        {
            Dictionary<int, int> scoresByMove = ScoresByMove(spaces, marker);
            KeyValuePair<int, int> highestScoreByMove = scoresByMove.Aggregate((left, right) => left.Value > right.Value ? left : right);
            return highestScoreByMove.Key;

        }


        private Dictionary<int, int> ScoresByMove(string[] spaces, string marker)
        {
            Dictionary<int, int> ScoresByMove = new Dictionary<int, int>();
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);
            List<string[]> nextBoards = Minimax.FindNextBoards(spaces, marker);
            int index = 0;

            foreach(string space in availableSpaces)
            {
                int depth = availableSpaces.Count();
                int move = Int32.Parse(space);
                int score = Minimax.MinOrMaxScore(nextBoards[index], marker, depth, true, depth, -1000, 1000);
                ScoresByMove.Add(move, score);
                index += 1;
            }

            return ScoresByMove;
        }

    }
}
