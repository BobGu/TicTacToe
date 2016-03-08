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
            List<string[]> children = Minimax.FindNextBoards(spaces, marker);
            int index = 0;

            foreach(string space in availableSpaces)
            {
                int depth = availableSpaces.Count();
                int move = Int32.Parse(space);
                int score = Minimax.MinOrMaxScore(children[index], marker, depth, true);
                ScoresByMove.Add(move, score);
                index += 1;
            }

            return ScoresByMove;
        }

    }
}
