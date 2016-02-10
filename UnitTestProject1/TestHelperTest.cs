using System;
using NUnit.Framework;
using TicTacToe;
namespace UnitTestProject1
{
    [TestFixture]
    public class TestHelperTest
    {
        [Test]
        public void BoardsFirstRowGetsFilledWithXs()
        {
            Board board = new Board();
            int[] spacesToBeMarked = { 0, 1, 2 };
            TestHelper.MarkBoardWithXsAtSpaces(board, spacesToBeMarked);
        }

    }
}
