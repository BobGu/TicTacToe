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
            StringWriter sw = CaptureTheOutput();
            MessagePrinter.AskPlayerForPiece();
            StringAssert.Contains("What piece would you like to be, X or O?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForTurnOrder()
        {
            StringWriter sw = CaptureTheOutput();
            MessagePrinter.AskForTurnOrder("Tony");
            string expected = "Type 1 if you would like Tony to go first, and 2 to go second";
            StringAssert.Contains(expected, sw.ToString());
        }

        [Test]
        public void MessageFactoryAFormattedEmptyBoard()
        {
            StringWriter sw = CaptureTheOutput();
            string[] spaces= { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            MessagePrinter.FormatBoard(spaces);
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
            StringAssert.Contains(expected, sw.ToString());
        }

        [Test]
        public void APartiallyFilledAndFormatted_Board()
        {
            StringWriter sw = CaptureTheOutput();
            string[] spaces= { "X", "O", "2", "3", "4", "5", "6", "7", "8" };
            MessagePrinter.FormatBoard(spaces);
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
            StringAssert.Contains(expected, sw.ToString());

        }

        [Test]
        public void AMessageForTheWinner()
        {
            StringWriter sw = CaptureTheOutput();
            string winnersMessage = "Robert has won the game";
            MessagePrinter.Winner("Robert");
            StringAssert.Contains(winnersMessage, sw.ToString());
        }

        [Test]
        public void AMessageForATieGame()
        {
            StringWriter sw = CaptureTheOutput();
            string tiedMessage = "The game is a tie";
            MessagePrinter.Tied();
            StringAssert.Contains(tiedMessage, sw.ToString()); 
        }

        [Test]
        public void AMessageForInvalidInput()
        {
            StringWriter sw = CaptureTheOutput();
            string invalidMessage = "P is not a valid input";
            MessagePrinter.Invalid("P");
            StringAssert.Contains(invalidMessage, sw.ToString());
        }

        [Test]
        public void MessageForGameMode()
        {
            StringWriter sw = CaptureTheOutput();
            string gameModeMessage = "Type in hh to play human vs human, and hc for human vs computer";
            MessagePrinter.GameModes();
            StringAssert.Contains(gameModeMessage, sw.ToString());
        }
    }
}
