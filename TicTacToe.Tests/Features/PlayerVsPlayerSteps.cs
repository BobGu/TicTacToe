using System;
using TechTalk.SpecFlow;
using TicTacToe;
using System.IO;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TicTacToeTests.TestHelper;

namespace UnitTestProject1
{
    [Binding]
    public class PlayerVsPlayerSteps: Steps
    {
        public string[] gameOutput;
        public string gameInput;
        public Game game;

        public void FlushStandardOut()
        {
            StreamWriter standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        public void FlushStandardIn()
        {
            gameInput = "";
        }

        public StringWriter SetOutputToStringWriter()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            return sw;
        }

        public string[] CaptureOutput(StringWriter sw)
        {
            string output = sw.ToString();
            return gameOutput = output.Split(new[] { "\r\n"}, StringSplitOptions.None);
        }


        [Given(@"the game has started")]
        public void GivenTheGameHasStarted()
        {
            FlushStandardOut();
            FlushStandardIn();
            game = new Game();
        }

        [Then(@"I should be asked for my name")]
        public void ThenIShouldBeAskedForMyName()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.SetUp();
            CaptureOutput(sw);
            string expected = string.Format("What is your name?", Environment.NewLine);
            Assert.AreEqual(expected, gameOutput[0]);
        }

        [Given(@"I have already entered my name")]
        public void IHaveAlreadyEnteredMyName()
        {
            gameInput = "Robert\n";
        }

        [Then(@"I expect to be asked what piece I would like to be")]
        public void IExpectToBeAskedWhatPieceIWouldLikeToBe()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.SetUp();
            CaptureOutput(sw);
            string expected = "What piece would you like to be?";
            Assert.AreEqual(expected, gameOutput[1]);
        }

        [Given(@"the first player has entered their info")]
        public void TheFirstPayerHasEnteredTheirInfo()
        {
            gameInput = "Robert\nX\n";
        }

        [Then(@"the second player should be asked for their name")]
        public void TheSecondPlayerShouldBeAskedForTheirName()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.SetUp();
            CaptureOutput(sw);
            string expected = "What is your name?";
            Assert.AreEqual(expected, gameOutput[2]);
        }

        [Given(@"players have entered all their info")]
        public void PlayersHaveEnteredAllTheirInfo()
        {
            gameInput = "Robert\nX\nJohn\n";
        }

        [Then(@"I expect to be asked about the turn order")]
        public void IExpectToBeAskedAboutTheTurnOrder()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.SetUp();
            CaptureOutput(sw);
            string expected = "Type 1 if you would like Robert to go first, and 2 to go second";
            Assert.AreEqual(expected, gameOutput[3]);
        }

        [Given(@"player one chooses to go first")]
        public void PlayerOneChoosesToGoFirst()
        {
            gameInput = gameInput + "1\n";
        }

        [Then(@"I expect player one to be asked where they would like to move")]
        public void IExpectPlayerOneToBeAskedWhereTheyWouldLikeToMove()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.Start();
            CaptureOutput(sw);
            string expected = "Where would you like to move Robert?";
            Assert.AreEqual(expected, gameOutput[4]);
        }

        [Given(@"player one chooses to go second")]
        public void PlayerOneChoosesToGoSecond()
        {
            gameInput = gameInput + "2\n";
        }

        [Then(@"I expect player two to be asked where they would like to move")]
        public void IExpectPlayerTwoToBeAskedWhereTheyWouldLikeToMove()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.Start();
            CaptureOutput(sw);
            string expected = "Where would you like to move John?";
            Assert.AreEqual(expected, gameOutput[4]);
        }

        [Given(@"game setup is already done")]
        public void GameSetupIsAlreadyDone()
        {
            Given("the game has started");
            Given("players have entered all their info");
            Given("player one chooses to go first");
        }

        [Then(@"I expect to see an empty board")]
        public void IExpectToSeeAnEmptyBoard()
        {
            TestHelper.SetInput(gameInput);
            string expected =
                @"     |     |     |
                   0   |  1  |  2  |
                  _____|_____|_____|
                       |     |     |
                   3   |  4  |  5  |
                  _____|_____|_____|
                       |     |     |
                   6   |  7  |  8  |
                  _____|_____|_____|";

            StringWriter sw = SetOutputToStringWriter();
            game.Start();
            string output = sw.ToString();
            StringAssert.Contains(expected, output);
        
        }

    }
}
