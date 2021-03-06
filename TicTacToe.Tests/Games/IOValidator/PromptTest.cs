﻿using NUnit.Framework;
using TicTacToe.Games.IOValidator;

namespace TicTacToe.Tests.Games.IOValidator
{

using TicTacToe.Tests.TestHelper;
    [TestFixture]
    public class PromptTest
    {

        [Test]
        public void ReturnsAName()
        {
            TestHelper.SetInput("Kirby\n");
            string name = Prompt.GetPlayerName();
            Assert.AreEqual("Kirby", name);
        }

        [Test]
        public void ReturnsAMarker()
        {
            TestHelper.SetInput("X\n");
            string marker = Prompt.GetInput(MessageHandler.AskPlayerForMarker, Validator.Marker);
            Assert.AreEqual("X", marker);
        }

        [Test]
        public void AsksForMarkerAgainIfInvalid()
        {
            TestHelper.SetInput("P\nO\n");
            string marker = Prompt.GetInput(MessageHandler.AskPlayerForMarker, Validator.Marker);
            Assert.AreNotEqual("P", marker);
            Assert.AreEqual("O", marker);
        }


        [Test]
        public void ReturnsAMove()
        {
            TestHelper.SetInput("4\n");
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            int move = Prompt.GetPlayerMove("Bob", spaces);
            Assert.AreEqual(4, move);
        }

        [Test]
        public void GetTurnOrder()
        {
            TestHelper.SetInput("1\n");
            string turnOrder = Prompt.GetTurnOrder("Bob");
            Assert.AreEqual("1", turnOrder);
        }

        [Test]
        public void DoesNotAcceptAnInvalid_Turn_Order()
        {
            TestHelper.SetInput("3\n2\n");
            string turnOrder = Prompt.GetTurnOrder("Robert");
            Assert.AreNotEqual("3", turnOrder);
            Assert.AreEqual("2", turnOrder);
        }

        [Test]
        public void DoesNotAcceptInvalidMove()
        {
            TestHelper.SetInput("fake move!\n2\n");
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            int move = Prompt.GetPlayerMove("Robert", spaces);
            Assert.AreEqual(2, move);
            Assert.AreNotEqual("fake move", move);
        }

        [Test]
        public void ReturnsAGameModeIfValid()
        {
            TestHelper.SetInput("hc\n");
            Assert.AreEqual("HC", Prompt.GetInput(MessageHandler.AskPlayerForGameMode, Validator.GameMode));
        }

        [Test]
        public void ReturnsAStrategyLevel()
        {
            TestHelper.SetInput("E\n");
            Assert.AreEqual("E", Prompt.GetInput(MessageHandler.AskPlayerForStrategyLevel, Validator.StrategyLevel));
        }
        [Test]
        public void ReturnsValidInputIfValidGameModes()
        {
            TestHelper.SetInput("fun game mode\nHH\n");
            string input = Prompt.GetInput(MessageHandler.AskPlayerForGameMode, Validator.GameMode); 
            Assert.AreNotEqual("fun game mode", input);
            Assert.AreEqual("HH", input);
        }

        [Test]
        public void ReturnsValidInputIfValidTurnOrder()
        {
            TestHelper.SetInput("80th\n1\n");
            string input = Prompt.GetInput(MessageHandler.AskPlayerForGameMode, Validator.TurnOrder);
            Assert.AreNotEqual("80th", input);
            Assert.AreEqual("1", input);
        }
    }

}
