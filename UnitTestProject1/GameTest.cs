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
            Assert.IsFalse(game.Over(spaces));
        }

        [Test]
        public void GameIsWonWhenOnePieceHasFilledTopRow()
        {
            game.board.spaces[0] = "X";
            game.board.spaces[1] = "X";
            game.board.spaces[2] = "X";
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
            game.board.spaces[3] = "X";
            game.board.spaces[4] = "X";
            game.board.spaces[5] = "X";
            bool result = game.Won();
            Assert.IsTrue(result);
        }

        [Test]
        public void GameIsWonWhenBottomRowFilled()
        {
            game.board.spaces[6] = "O";
            game.board.spaces[7] = "O";
            game.board.spaces[8] = "O";
            bool result = game.Won();
            Assert.IsTrue(result);
        }


    }
    
}
