using System;
using System.Linq;
using TicTacToe;

namespace UnitTestProject1
{
    public class TestHelper
    {
        public static void MarkBoardWithXsBeginningToEnd(Board board, int beginMarking, int endMarking)
        {
            for (int i = beginMarking; i <= endMarking; i++)
            {
                board.spaces[i] = "X";
            }
        }
    }

}
