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
            MessagePrinter.AskPlayerForMove("Robert");
            StringAssert.Contains("Where would you like to move Robert?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForAName()
        {
            StringWriter sw = CaptureTheOutput();
            MessagePrinter.AskPlayerForName();
            StringAssert.Contains("What is your name?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForAPiece()
        {
            string pieceMessage = MessagePrinter.AskPlayerForPiece();
            Assert.AreEqual("What piece would you like to be, X or O?", pieceMessage);
        }

        [Test]
        public void MessageFactoryAskForTurnOrder()
        {
            string turnOrderMessage = MessagePrinter.AskForTurnOrder("Tony");
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
            StringAssert.Contains(expected, MessagePrinter.FormatBoard(spaces));
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
            StringAssert.Contains(expected, MessagePrinter.FormatBoard(spaces));

        }

        [Test]
        public void AMessageForTheWinner()
        {
            string winnersMessage = "Robert has won the game";
            Assert.AreEqual(winnersMessage, MessagePrinter.Winner("Robert"));
        }

        [Test]
        public void AMessageForATieGame()
        {
            string tiedMessage = "The game is a tie";
            Assert.AreEqual(tiedMessage, MessagePrinter.Tied());
        }

        [Test]
        public void AMessageForInvalidInput()
        {
            string invalidMessage = "P is not a valid input";
            Assert.AreEqual(invalidMessage, MessagePrinter.Invalid("P"));
        }

        [Test]
        public void MessageForGameMode()
        {
            string gameModeMessage = "Type in hh to play human vs human, and hc for human vs computer";
            Assert.AreEqual(gameModeMessage, MessagePrinter.GameModes());
        }
    }
}
