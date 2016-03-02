using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class EasyStrategy
    {
        public bool PossibleWinningSet(string[] spaces, string marker)
        {
            int numberOfMarkersInSet = spaces.Where(space => space == marker).Count();
            int numberOfEmptySpaces = spaces.Where(space => !BoardEvaluator.IsNotAnEmptySpace(space)).Count();
            return numberOfMarkersInSet == 2 && numberOfEmptySpaces == 1;
        }

        public bool CanWin(string[] spaces, string marker)
        {
            return BoardEvaluator.RowsColumnsDiagonals(spaces).Any(set => PossibleWinningSet(set, marker));
        }
    }
}
