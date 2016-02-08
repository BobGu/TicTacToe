using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;
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
            string[] filledBoardSpaces = { "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            bool gameOverFilledBoardSpaces = game.Over(filledBoardSpaces);
            Assert.IsTrue(gameOverFilledBoardSpaces);
            string[] mixedBoardSpaces = { "O", "X", "O", "X", "O", "X", "O", "X", "O" };
            bool gameOverMixedBoardSpaces = game.Over(mixedBoardSpaces);
            Assert.IsTrue(gameOverMixedBoardSpaces);
        }

        [Test]
        public void GameIsNotOverWhenBoardIsEmpty()
        {
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            bool result = game.Over(spaces);
            Assert.IsFalse(result);
        }

        [Test]
        public void GameIsWonWhenOnePieceHasFilledTopRow()
        {
            string[] xFilledTopRow = { "X", "X", "X", "3", "4", "5", "6", "7", "8" };
            bool gameWonForX = game.Won(xFilledTopRow);
            Assert.IsTrue(gameWonForX);

            string[] oFilledTopRow = { "O", "O", "O", "3", "4", "5", "6", "7", "8" };
            bool gameWonForO = game.Won(oFilledTopRow);
            Assert.IsTrue(gameWonForO);
        }

        [Test]
        public void GameIsNotWonTopRowIsFilledWithMixedPieces()
        {
            string[] spaces = { "X", "O", "X", "3", "4", "5", "6", "7", "8" };
            bool gameWon = game.Won(spaces);
            Assert.IsFalse(gameWon);
        }

        [Test]
        public void GameIsWonWhenOnePieceHasFilledSecondRow()
        {
            string[] spaces= { "0", "1", "2", "X", "X", "X", "6", "7", "8" };
            bool result = game.Won(spaces);
            Assert.IsTrue(result);
        }

        [Test]
        public void GameIsWonWhenBottomRowFilled()
        {
            string[] spaces = { "0", "1", "2", "3", "4", "5", "X", "X", "X" };
            bool result = game.Won(spaces);
            Assert.IsTrue(result);
        }


    }
    
}
