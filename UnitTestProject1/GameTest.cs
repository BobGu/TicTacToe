using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;
using UnitTestProject1;
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
        public void GameStartsWithoutAWinner()
        {
            Assert.IsFalse(game.Won());
        }

        [Test]
        public void GameStartsWithTwoPlayers()
        {
            int playerCount = game.players.Length;
            Assert.AreEqual(2, playerCount);
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
        public void GameIsOverWhenBoardIsFilled()
        {
            int[] spacesToBeMarked = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            TestHelper.MarkBoardWithXsAtSpaces(game.board, spacesToBeMarked);
            bool gameOverFilledBoardSpaces = game.Over();
            Assert.IsTrue(gameOverFilledBoardSpaces);
        }

        [Test]
        public void GameIsNotOverWhenBoardIsEmpty()
        {
            Assert.IsFalse(game.Over());
        }

        [Test]
        public void GameIsOverWhenGameIsWon()
        {
            int[] spacesToBeMarked = { 0, 1, 2};
            string[][] rows = game.board.Rows();
            TestHelper.MarkBoardWithXsAtSpaces(game.board, spacesToBeMarked);
            Assert.IsTrue(game.Over());
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledTopRow()
        {
            int[] spacesToBeMarked = { 0, 1, 2 };
            TestHelper.MarkBoardWithXsAtSpaces(game.board, spacesToBeMarked);
            bool gameWonForX = game.Won();
            Assert.IsTrue(gameWonForX);
        }

        [Test]
        public void GameIsNotWonTopRowIsFilledWithMixedMarkers()
        {
            game.board.spaces[0] = "X";
            game.board.spaces[1] = "O";
            game.board.spaces[2] = "X";
            bool gameWon = game.Won();
            Assert.IsFalse(gameWon);
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledSecondRow()
        {
            int[] spacesToBeMarked = { 3, 4, 5 };
            TestHelper.MarkBoardWithXsAtSpaces(game.board, spacesToBeMarked);
            bool result = game.Won();
            Assert.IsTrue(result);
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledBottomRow()
        {
            int[] spacesToBeMarked = { 6, 7, 8 };
            TestHelper.MarkBoardWithXsAtSpaces(game.board, spacesToBeMarked);
            bool result = game.Won();
            Assert.IsTrue(result);
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledFirstColumn()
        {
            int[] spacesToBeMarked = { 0, 3, 6 };
            TestHelper.MarkBoardWithXsAtSpaces(game.board, spacesToBeMarked);
            bool result = game.Won();
            Assert.IsTrue(result);
        }
    }
    
}
