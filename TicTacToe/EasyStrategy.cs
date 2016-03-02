using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class EasyStrategy
    {
        public string[] FilterSetForMarker(string[] set, string marker)
        {
            return set.Where(space => space == marker).ToArray();
        }
        public bool TwoMarkersInSet(string[] set, string marker)
        {
            return FilterSetForMarker(set, marker).Count() == 2;
        }
        public bool PossibleWinningSet(string[] set, string marker)
        {
            int numberOfEmptySpaces = set.Where(space => !BoardEvaluator.IsNotAnEmptySpace(space)).Count();
            return TwoMarkersInSet(set, marker) && numberOfEmptySpaces == 1;
        }

        public bool CanWin(string[] spaces, string marker)
        {
            return BoardEvaluator.RowsColumnsDiagonals(spaces).Any(set => PossibleWinningSet(set, marker));
        }
    }
}
