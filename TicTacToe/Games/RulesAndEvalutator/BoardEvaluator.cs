using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.GlobalConstants;

namespace TicTacToe.Games.RulesAndEvaluator
{
    public class BoardEvaluator
    {
        public static bool IsAnEmptySpace(string space)
        {
            return space != GlobalConstant.XMarker && space != GlobalConstant.OMarker;
        }

        public static bool AllSpacesNotEmpty(string[] spaces)
        {
            return spaces.All(space => !IsAnEmptySpace(space));
        }

        public static string[] AvailableSpaces(string[] spaces)
        {
            return spaces.Where(space => IsAnEmptySpace(space)).ToArray();
        }

        public static bool AnySetsTheSame(string[] spaces)
        {
            return RowsColumnsDiagonals(spaces).Any(set => AllSpacesTheSame(set));
        }

        public static string[][] RowsColumnsDiagonals(string[] spaces)
        {
            string[][] rowsColumnsDiagonals = new string[8][];
            Rows(spaces).CopyTo(rowsColumnsDiagonals, 0);
            Columns(spaces).CopyTo(rowsColumnsDiagonals, 3);
            Diagonals(spaces).CopyTo(rowsColumnsDiagonals, 6);
            return rowsColumnsDiagonals;
        } 

        private static bool AllSpacesTheSame(string[] spaces)
        {
            return 1 == spaces.Distinct().Count();
        }

        public static string[][] Rows(string[] spaces)
        {

            double squareRootOfBoardLength = Math.Sqrt(spaces.Length);
            int lengthOfRow = Convert.ToInt32(squareRootOfBoardLength);
            string[][] rows = new string[lengthOfRow][];
            for (int i = 0; i < lengthOfRow; i += 1)
            {
                string[] row = spaces.SubArray(i * lengthOfRow, lengthOfRow);
                rows[i] = row;
            }
            return rows;
        }

        private static string[][] Columns(string[] spaces)
        {
            string[][] columns = new string[3][];
            columns[0] = new string[] { spaces[0], spaces[3], spaces[6] };
            columns[1] = new string[] { spaces[1], spaces[4], spaces[7] };
            columns[2] = new string[] { spaces[2], spaces[5], spaces[8] };
            return columns;
        }

        private static string[][] Diagonals(string[] spaces)
        {
            string[][] diagonals = new string[2][];
            diagonals[0] = new string[] { spaces[0], spaces[4], spaces[8] };
            diagonals[1] = new string[] { spaces[2], spaces[4], spaces[6] };
            return diagonals;
        }

    }

}
