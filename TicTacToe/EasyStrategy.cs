using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class EasyStrategy : IComputerDifficulty
    {
        public string[] FilterSetForMarker(string[] set, string marker)
        {
            return set.Where(space => space == marker).ToArray();
        }

        public bool TwoMarkersInSet(string[] set, string marker)
        {
            return FilterSetForMarker(set, marker).Count() == 2;
        }

        public string[] FilterSetForEmptySpaces(string[] set)
        {
            return set.Where(space => !BoardEvaluator.IsNotAnEmptySpace(space)).ToArray();
        }

        public bool PossibleWinningSet(string[] set, string marker)
        {
            return TwoMarkersInSet(set, marker) && FilterSetForEmptySpaces(set).Count() == 1;
        }

        public bool CanWin(string[][] sets, string marker)
        {
            return sets.Any(set => PossibleWinningSet(set, marker));
        }

        public string[] FindWinningSet(string[][] sets, string marker)
        {
            return sets.Where(set => PossibleWinningSet(set, marker)).First();
        }

        public string FindWinningMove(string[] winningSet)
        {
            return FilterSetForEmptySpaces(winningSet).First();
        }

        public string RandomMove(string[] spaces)
        {
            Random rnd = new Random();
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);
            int randomSpace = rnd.Next(availableSpaces.Count());
            return availableSpaces[randomSpace];
        }

        public int BestMove(string[] spaces, string marker)
        {
            string[][] sets = BoardEvaluator.RowsColumnsDiagonals(spaces);
            string bestMove;

            if(CanWin(sets, marker))
            {
                bestMove = FindWinningMove(FindWinningSet(sets, marker));
            }
            else
            {
                bestMove = RandomMove(spaces);
            }

            return Int32.Parse(bestMove);
        }

    }
}
