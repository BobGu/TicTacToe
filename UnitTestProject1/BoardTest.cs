using System;
using TicTacToe;
namespace UnitTestProject1
{
    using NUnit.Framework;

    [TestFixture]
    public class BoardTest
    {

        Board board;

        [SetUp]
        public void CreateEmptyBoard()
        {
            board = new Board();
        }

        [Test]
        public void IsEmptyByDefault()
        {
            string[] emptyBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.AreEqual(emptyBoard, board.spaces);
        }

        [Test]
        public void OrganizesSpacesAsRows()
        {
            string[][] emptyRows = new string[3][];
            emptyRows[0] = new string[] { "0", "1", "2" };
            emptyRows[1] = new string[] { "3", "4", "5" };
            emptyRows[2] = new string[] { "6", "7", "8"};
            Assert.AreEqual(emptyRows, board.Rows());

            string[][] topRowXRows = emptyRows;
            board.spaces[0] = "X";
            board.spaces[1] = "X";
            board.spaces[2] = "X";
            topRowXRows[0] = new string[] { "X", "X", "X" };
            CollectionAssert.AreEqual(topRowXRows, board.Rows());
        }

        [Test]
        public void MarksSpaceWithGivenPiece()
        {
            board.Mark(4, "X");
            Assert.AreEqual("X", board.GetSpaceAt(4));
        }


        
    }
}
