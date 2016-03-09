using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class EasyStrategy : IComputerStrategy
    {

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

        public string RandomMove(string[] spaces)
        {
            Random rnd = new Random();
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);
            int randomSpace = rnd.Next(availableSpaces.Count());
            return availableSpaces[randomSpace];
        }

        private bool CanWin(string[][] sets, string marker)
        {
            return sets.Any(set => PossibleWinningSet(set, marker));
        }

        private string[] FindWinningSet(string[][] sets, string marker)
        {
            return sets.Where(set => PossibleWinningSet(set, marker)).First();
        }
        private bool PossibleWinningSet(string[] set, string marker)
        {
            return TwoMarkersInSet(set, marker) && FilterSetForEmptySpaces(set).Count() == 1;
        }

        private string FindWinningMove(string[] winningSet)
        {
            return FilterSetForEmptySpaces(winningSet).First();
        }

        private string[] FilterSetForMarker(string[] set, string marker)
        {
            return set.Where(space => space == marker).ToArray();
        }

        private bool TwoMarkersInSet(string[] set, string marker)
        {
            return FilterSetForMarker(set, marker).Count() == 2;
        }

        private string[] FilterSetForEmptySpaces(string[] set)
        {
            return set.Where(space => BoardEvaluator.IsAnEmptySpace(space)).ToArray();
        }

    }
}
