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
    public class PlayerVsPlayerSteps
    {
        public string[] gameOutput;
        public string gameInput;

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


        [Given(@"the game has started")]
        public void GivenTheGameHasStarted()
        {
            FlushStandardOut();
            FlushStandardIn();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Game game = new Game();
            game.Start();
            string output = sw.ToString();
            gameOutput = output.Split(new[] { "\r\n"}, StringSplitOptions.None);
        }

        [Then(@"I should be asked for my name")]
        public void ThenIShouldBeAskedForMyName()
        {
            TestHelper.SetInput(gameInput);
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
            string expected = "Where would you like to move John?";
            Assert.AreEqual(expected, gameOutput[4]);
        }

    }
}
