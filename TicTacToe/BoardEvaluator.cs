using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class BoardEvaluator
    {
        public const string xMarker = "X";
        public const string oMarker = "O";

        public static bool IsNotAnEmptySpace(string space)
        {
            return space == xMarker || space == oMarker;
        }

        public static bool AllSpacesTheSame(string[] spaces)
        {
            return 1 == spaces.Distinct().ToArray().Length;
        }
    }
}
