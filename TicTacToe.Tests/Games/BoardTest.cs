using System;
using TicTacToe.Games;
namespace TicTacToe.Tests.Games
{
    using NUnit.Framework;

    [TestFixture]
    public class BoardTest
    {

        Board board;

        [SetUp]
        public void CreateBoardWithDimmensions()
        {
            board = new Board(3);
        }

        [Test]
        public void SpacesAreEmptyUponCreation()
        {
            string[] emptyBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.AreEqual(emptyBoard, board.spaces);
        }

        [Test]
        public void MarksSpaceWithGivenPiece()
        {
            board.Mark(4, "X");
            Assert.AreEqual("X", board.GetSpaceAt(4));
        }

    }
}
