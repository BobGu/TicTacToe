using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;

namespace TicTacToeTests
{
    [TestFixture]
    public class MessageFactoryTest
    {
        [Test]
        public void Ask_For_Move()
        {
            string name = "Robert";
            string moveMessage = MessageFactory.AskPlayerForMove(name);
            Assert.AreEqual("Where would you like to move Robert?", moveMessage);
        }

        [Test]
        public void Ask_For_A_Name()
        {
            string nameMessage = MessageFactory.AskPlayerForName();
            Assert.AreEqual("What is your name?", nameMessage);
        }

        [Test]
        public void Ask_For_A_Piece()
        {
            string pieceMessage = MessageFactory.AskPlayerForPiece();
            Assert.AreEqual("What piece would you like to be?", pieceMessage);
        }

        [Test]
        public void Ask_For_Turn_Order()
        {
            string turnOrderMessage = MessageFactory.AskForTurnOrder("Tony");
            string expected = "Type 1 if you would like Tony to go first, and 2 to go second";
            Assert.AreEqual(expected, turnOrderMessage);
        }
    }
}
