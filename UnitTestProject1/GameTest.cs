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
            TestHelper.MarkBoardWithXsBeginningToEnd(game.board, 0, 8);
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
            string[][] rows = game.board.Rows();
            TestHelper.MarkBoardWithXsBeginningToEnd(game.board, 0, 2);
            Assert.IsTrue(game.Over());
        }

        [Test]
        public void GameIsWonWhenOnePieceHasFilledTopRow()
        {
            TestHelper.MarkBoardWithXsBeginningToEnd(game.board, 0, 2);
            bool gameWonForX = game.Won();
            Assert.IsTrue(gameWonForX);
        }

        [Test]
        public void GameIsNotWonTopRowIsFilledWithMixedPieces()
        {
            game.board.spaces[0] = "X";
            game.board.spaces[1] = "O";
            game.board.spaces[2] = "X";
            bool gameWon = game.Won();
            Assert.IsFalse(gameWon);
        }

        [Test]
        public void GameIsWonWhenOnePieceHasFilledSecondRow()
        {
            TestHelper.MarkBoardWithXsBeginningToEnd(game.board, 3, 5);
            bool result = game.Won();
            Assert.IsTrue(result);
        }

        [Test]
        public void GameIsWonWhenBottomRowFilled()
        {
            TestHelper.MarkBoardWithXsBeginningToEnd(game.board, 6, 8);
            bool result = game.Won();
            Assert.IsTrue(result);
        }


    }
    
}
