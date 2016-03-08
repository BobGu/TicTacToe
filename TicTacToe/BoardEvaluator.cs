using System;
using System.Collections.Generic;
using System.Linq;
using My.Extensions;

namespace TicTacToe
{
    public class BoardEvaluator
    {
        public static bool IsNotAnEmptySpace(string space)
        {
            return space == GlobalConstants.XMarker || space == GlobalConstants.OMarker;
        }

        public static bool AllSpacesNotEmpty(string[] spaces)
        {
            return spaces.All(space => IsNotAnEmptySpace(space));
        }

        public static string[] AvailableSpaces(string[] spaces)
        {
            return spaces.Where(space => !IsNotAnEmptySpace(space)).ToArray();
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

        private static string[][] Rows(string[] spaces)
        {
            string[][] rows = new string[3][];
            for (int i = 0; i < 3; i += 1)
            {
                string[] row = spaces.SubArray(i * 3, 3);
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
