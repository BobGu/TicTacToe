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
        public void GameAsksPlayerForTheirName()
        {
            string namePrompt = game.AskPlayerForName();
            Assert.AreEqual("What is your name?", namePrompt);
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
        public void GameAsksPlayerForMove()
        {
            string name = "Robert";
            string movePrompt = game.AskPlayerForMove(name);
            Assert.AreEqual(movePrompt, "Where would you like to move Robert");
        }

    }
    
}
