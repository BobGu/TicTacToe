using System;
using System.Collections.Generic;
using System.Linq;
using My.Extensions;

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

        public static bool AllSpacesNotEmpty(string[] spaces)
        {
            return spaces.All(space => IsNotAnEmptySpace(space));
        } 

        public static bool AllSpacesTheSame(string[] spaces)
        {
            return 1 == spaces.Distinct().ToArray().Length;
        }

        public static string[][] Rows(string[] spaces)
        {
            string[][] rows = new string[3][];
            int lengthOfRow = Convert.ToInt32(Math.Sqrt(spaces.Length));
            for (int i = 0; i < 3; i += 1)
            {
                string[] row = spaces.SubArray(i * lengthOfRow, lengthOfRow);
                rows[i] = row;
            }
            return rows;
        }
    }

}
