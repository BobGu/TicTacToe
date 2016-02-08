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
            string[] filledBoard = { "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            bool gameOverFilledBoard = game.Over(filledBoard);
            Assert.IsTrue(gameOverFilledBoard);
            string[] mixedBoard = { "O", "X", "O", "X", "O", "X", "O", "X", "O" };
            bool gameOverMixedBoard = game.Over(mixedBoard);
            Assert.IsTrue(gameOverMixedBoard);
        }

        [Test]
        public void GameIsNotOverWhenBoardIsEmpty()
        {
            string[] emptyBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            bool gameOverEmptyBoard = game.Over(emptyBoard);
            Assert.IsFalse(gameOverEmptyBoard);
        }



    }
    
}
