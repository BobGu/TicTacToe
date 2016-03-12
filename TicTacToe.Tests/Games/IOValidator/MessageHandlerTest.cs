using System;
using TicTacToe;
using NUnit.Framework;
using System.IO;
using TicTacToe.Games.IOValidator;

namespace TicTacToe.Tests.Games.IOValidator
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
            MessageHandler.AskPlayerForMove("Robert");
            StringAssert.Contains("Where would you like to move Robert?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForAName()
        {
            StringWriter sw = CaptureTheOutput();
            MessageHandler.AskPlayerForName();
            StringAssert.Contains("What is your name?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForAMarker()
        {
            StringWriter sw = CaptureTheOutput();
            MessageHandler.AskPlayerForMarker();
            StringAssert.Contains("What piece would you like to be, X or O?", sw.ToString());
        }

        [Test]
        public void MessageFactoryAskForTurnOrder()
        {
            StringWriter sw = CaptureTheOutput();
            MessageHandler.AskForTurnOrder("Tony");
            string expected = "Type 1 if you would like Tony to go first, and 2 to go second";
            StringAssert.Contains(expected, sw.ToString());
        }

        [Test]
        public void MessageFactoryAPrintedVersionOfTheBoard()
        {
            StringWriter sw = CaptureTheOutput();
            string[] spaces= { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            MessageHandler.PrintBoard(spaces);
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
        public void APartiallyFilledAndPrintedBoard()
        {
            StringWriter sw = CaptureTheOutput();
            string[] spaces= { "X", "O", "2", "3", "4", "5", "6", "7", "8" };
            MessageHandler.PrintBoard(spaces);
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
            MessageHandler.Winner("Robert");
            StringAssert.Contains(winnersMessage, sw.ToString());
        }

        [Test]
        public void AMessageForATieGame()
        {
            StringWriter sw = CaptureTheOutput();
            string tiedMessage = "The game is a tie";
            MessageHandler.Tied();
            StringAssert.Contains(tiedMessage, sw.ToString()); 
        }

        [Test]
        public void AMessageForInvalidInput()
        {
            StringWriter sw = CaptureTheOutput();
            string invalidMessage = "P is not a valid input";
            MessageHandler.Invalid("P");
            StringAssert.Contains(invalidMessage, sw.ToString());
        }

        [Test]
        public void MessageForGameMode()
        {
            StringWriter sw = CaptureTheOutput();
            string gameModeMessage = "Type in hh to play human vs human, and hc for human vs computer";
            MessageHandler.AskPlayerForGameMode();
            StringAssert.Contains(gameModeMessage, sw.ToString());
        }

        [Test]
        public void MessageForStrategy()
        {
            StringWriter sw = CaptureTheOutput();
            string message = "Type in E for easy or H for hard difficulty";
            MessageHandler.AskPlayerForStrategyLevel();
            StringAssert.Contains(message, sw.ToString());
        }

        [Test]
        public void MessageForDimmensionsOfBoard()
        {
            StringWriter sw = CaptureTheOutput();
            string message = "Type in 3 to play on a 3 by 3 board, or 4 for a 4 by 4 board";
            MessageHandler.AskPlayerForBoardDimmensions();
            StringAssert.Contains(message, sw.ToString());
        }
    }

}
