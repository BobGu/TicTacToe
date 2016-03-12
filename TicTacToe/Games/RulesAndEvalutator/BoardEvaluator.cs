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

        private static string[][] Rows(string[] spaces)
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

        public static string[][] Columns(string[] spaces)
        {
            double squareRootOfBoardLength = Math.Sqrt(spaces.Length);
            int lengthOfColumn = Convert.ToInt32(squareRootOfBoardLength);
            string[][] columns = new string[lengthOfColumn][];

            for(int i = 0; i < lengthOfColumn; i += 1)
            {
                string[] column = new string[lengthOfColumn];
                for(int j = 0; j < lengthOfColumn; j += 1)
                {
                    int index = i + (j * lengthOfColumn);
                    column[j] = spaces[index];
                }

                columns[i] = column;
            }

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
