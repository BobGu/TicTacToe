using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;
using UnitTestProject1;
using Moq;
namespace GameTest
{
    [TestFixture]
    public class GameTest
    {
        Game game;
        [SetUp]
        public void StartANewGame()
        {
            game = new Game();
            game.Start();
        }

        [Test]
        public void GameGetsPlayerName()
        {
            StringReader reader = new StringReader("Kirby\n");
            Console.SetIn(reader);
            string name = game.GetPlayerName();
            Assert.AreEqual("Kirby", name);
        }

        [Test]
        public void GameGetsPlayerMove()
        {
            StringReader reader = new StringReader("4\n");
            Console.SetIn(reader);
            string move = game.GetPlayerMove("Bob");
            Assert.AreEqual("4", move);
        }

        [Test]
        public void GameIsOverWhenBoardIsFilledAndNotWon()
        {
            string[] spaces = { "X", "O", "X",
                                "X", "X", "O",
                                "O", "X", "O" };
            Assert.IsTrue(game.Over(spaces));
        }

        [Test]
        public void GameIsNotOverWhenBoardIsEmpty()
        {
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsFalse(game.Over(spaces));
        }

        [Test]
        public void GameIsOverWhenGameIsWon()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8"};
            Assert.IsTrue(game.Over(spaces));
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledTopRow()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsNotWonTopRowIsFilledWithMixedMarkers()
        {
            string[] spaces = { "X", "O", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsFalse(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenSecondRowIsFilledWithOneMarker()
        {
            string[] spaces = { "0", "1", "2", 
                                "X", "X", "X", 
                                "6", "7", "8" };
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenThirdRowIsFilledWithOneMarker()
        {
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5", 
                                "X", "X", "X" };
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenFirstColumnIsFilledWithOneMarker()
        {
            string[] spaces = { "O", "1", "2",
                                "O", "4", "5",
                                "O", "7", "8"};
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameCanTellBoardToMarkItself()
        {
            Board board = new Board();
            game.MarkBoard(board, 4, "X");
            Assert.AreEqual("X", board.GetSpaceAt(4));
        }
    }
    
}
