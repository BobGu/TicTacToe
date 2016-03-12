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
            double squareRootOfBoardLength = Math.Sqrt(spaces.Length);
            int lengthOfRow = Convert.ToInt32(squareRootOfBoardLength);
            int numberOfRowsColumnsDiagoals = lengthOfRow + lengthOfRow + 2;

            string[][] rowsColumnsDiagonals = new string[numberOfRowsColumnsDiagoals][];
            Rows(spaces).CopyTo(rowsColumnsDiagonals, 0);
            Columns(spaces).CopyTo(rowsColumnsDiagonals, lengthOfRow);
            Diagonals(spaces).CopyTo(rowsColumnsDiagonals, lengthOfRow + lengthOfRow);
            return rowsColumnsDiagonals;
        } 

        private static bool AllSpacesTheSame(string[] spaces)
        {
            return 1 == spaces.Distinct().Count();
        }

        public static string[][] Rows(string[] spaces)
        {
            int lengthOfRow = WidthOfBoard(spaces);
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
            int lengthOfColumn = WidthOfBoard(spaces);
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
            int lengthOfDiagonal = WidthOfBoard(spaces);

            diagonals[0] = FirstDiagonal(spaces);
            diagonals[1] = SecondDiagonal(spaces);

            return diagonals;
        }

        public static int WidthOfBoard(string[] spaces)
        {
            double squareRootOfBoardLength = Math.Sqrt(spaces.Length);
            return Convert.ToInt32(squareRootOfBoardLength);
        }

        private static string[] FirstDiagonal(string[] spaces)
        {
            int lengthOfDiagonal = WidthOfBoard(spaces);
            int numberOfSpacesBetweenNextIndex = lengthOfDiagonal + 1;
            string[] diagonal = new string[lengthOfDiagonal];

            for(int j = 0; j < lengthOfDiagonal; j += 1)
            {
                int index = j * numberOfSpacesBetweenNextIndex;
                diagonal[j] = spaces[index];
            }

            return diagonal;
        }
        private static string[] SecondDiagonal(string[] spaces)
        {
            int lengthOfDiagonal = WidthOfBoard(spaces);
            int numberOfSpacesBetweenNextIndex = lengthOfDiagonal + -1;
            string[] diagonal = new string[lengthOfDiagonal];

            for(int j = 0; j < lengthOfDiagonal; j += 1)
            {
                int index = numberOfSpacesBetweenNextIndex + (j * numberOfSpacesBetweenNextIndex);
                diagonal[j] = spaces[index];
            }

            return diagonal;
        }


    }

}
