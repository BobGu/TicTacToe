using System;
using System.Linq;
using TicTacToe;

namespace UnitTestProject1
{
    public class TestHelper
    {
        public static void MarkBoardWithXsAtSpaces(Board board, int[] indexes)
        {
            foreach(int index in indexes)
            {
                board.spaces[index] = "X";
            }
        }
    }

}
