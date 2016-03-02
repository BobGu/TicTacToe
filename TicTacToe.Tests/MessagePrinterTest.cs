using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;

namespace TicTacToeTests
{
    [TestFixture]
    public class MessageFactoryTest
    {

        public StringWriter CaptureTheOutput()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            return sw;
        }

        [Test]
        public void MessageFactoryAskForMove()
        {
            StringWriter sw = CaptureTheOutput();
            MessageFactory.AskPlayerForMove("Robert");
            StringAssert.Contains("Where would you like to move Robert?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForAName()
        {
            string nameMessage = MessageFactory.AskPlayerForName();
            Assert.AreEqual("What is your name?", nameMessage);
        }

        [Test]
        public void MessageFactoryAskForAPiece()
        {
            string pieceMessage = MessageFactory.AskPlayerForPiece();
            Assert.AreEqual("What piece would you like to be, X or O?", pieceMessage);
        }

        [Test]
        public void MessageFactoryAskForTurnOrder()
        {
            string turnOrderMessage = MessageFactory.AskForTurnOrder("Tony");
            string expected = "Type 1 if you would like Tony to go first, and 2 to go second";
            Assert.AreEqual(expected, turnOrderMessage);
        }

        [Test]
        public void MessageFactoryAFormattedEmptyBoard()
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
        public void APartiallyFilledAndFormatted_Board()
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
        public void AMessageForTheWinner()
        {
            string winnersMessage = "Robert has won the game";
            Assert.AreEqual(winnersMessage, MessageFactory.Winner("Robert"));
        }

        [Test]
        public void AMessageForATieGame()
        {
            string tiedMessage = "The game is a tie";
            Assert.AreEqual(tiedMessage, MessageFactory.Tied());
        }

        [Test]
        public void AMessageForInvalidInput()
        {
            string invalidMessage = "P is not a valid input";
            Assert.AreEqual(invalidMessage, MessageFactory.Invalid("P"));
        }

        [Test]
        public void MessageForGameMode()
        {
            string gameModeMessage = "Type in hh to play human vs human, and hc for human vs computer";
            Assert.AreEqual(gameModeMessage, MessageFactory.GameModes());
        }
    }
}
