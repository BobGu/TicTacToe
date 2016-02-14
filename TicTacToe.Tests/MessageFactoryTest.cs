using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;

namespace UnitTestProject1
{
    [TestFixture]
    public class MessageFactoryTest
    {
        [Test]
        public void Ask_For_Move()
        {
            string name = "Robert";
            string movePrompt = MessageFactory.AskPlayerForMove(name);
            Assert.AreEqual(movePrompt, "Where would you like to move Robert");
        }

        [Test]
        public void Ask_For_A_Name()
        {
            string namePrompt = MessageFactory.AskPlayerForName();
            Assert.AreEqual("What is your name?", namePrompt);
        }

        [Test]
        public void Ask_for_A_Piece()
        {
            string piecePrompt = MessageFactory.AskPlayerForPiece();
            Assert.AreEqual("What piece would you like to be?", piecePrompt);
        }
    }
}
