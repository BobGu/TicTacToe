using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
namespace UnitTestProject1
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void TestEmptyBoard()
        {
            Board board = new Board();
            int[] emptyBoard = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            CollectionAssert.AreEquivalent(emptyBoard, board.spaces);
        }
    }
}
