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
    }
}
