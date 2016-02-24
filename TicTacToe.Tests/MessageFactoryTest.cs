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
            Assert.AreEqual("What piece would you like to be, X or O?", pieceMessage);
        }

        [Test]
        public void Ask_For_Turn_Order()
        {
            string turnOrderMessage = MessageFactory.AskForTurnOrder("Tony");
            string expected = "Type 1 if you would like Tony to go first, and 2 to go second";
            Assert.AreEqual(expected, turnOrderMessage);
        }

        [Test]
        public void A_Formatted_Empty_Board()
        {
            string[] spaces= { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string expected =
                @"              

                   0   |  1  |  2  |
                  _____|_____|_____|
                       |     |     |
                   3   |  4  |  5  |
                  _____|_____|_____|
                       |     |     |
                   6   |  7  |  8  |
                  _____|_____|_____|";
            StringAssert.Contains(expected, MessageFactory.FormatBoard(spaces));
        }

        [Test]
        public void A_Partially_Filled_And_Formatted_Board()
        {
            string[] spaces= { "X", "O", "2", "3", "4", "5", "6", "7", "8" };
            string expected =
                @"              

                   X   |  O  |  2  |
                  _____|_____|_____|
                       |     |     |
                   3   |  4  |  5  |
                  _____|_____|_____|
                       |     |     |
                   6   |  7  |  8  |
                  _____|_____|_____|";
            StringAssert.Contains(expected, MessageFactory.FormatBoard(spaces));

        }

        [Test]
        public void A_Message_For_The_Winner()
        {
            string winnersMessage = "Robert has won the game";
            Assert.AreEqual(winnersMessage, MessageFactory.Winner("Robert"));
        }

        [Test]
        public void A_Message_For_A_Tie_Game()
        {
            string tiedMessage = "The game is a tie";
            Assert.AreEqual(tiedMessage, MessageFactory.Tied());
        }

        [Test]
        public void A_Message_For_Invalid_Input()
        {
            string invalidMessage = "P is not a valid input";
            Assert.AreEqual(invalidMessage, MessageFactory.Invalid("P"));
        }
    }
}
