using System;
using NUnit.Framework;
using TicTacToe;
namespace UnitTestProject1
{
    [TestFixture]
    public class TestHelperTest
    {
        [Test]
        public void BoardGetsFilledWithXs()
        {
            Board board = new Board();
            TestHelper.MarkBoardWithXsBeginningToEnd(board, 0, 8);
            string[] filledSpaces = { "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            CollectionAssert.AreEqual(filledSpaces, board.spaces);
        }
    }
}
