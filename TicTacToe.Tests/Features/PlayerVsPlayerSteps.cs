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

        [Given(@"the game has started")]
        public void GivenTheGameHasStarted()
        {
            StringWriter sw = new StringWriter();
            Game game = new Game();
            Console.SetOut(sw);
            game.Start();
            string output = sw.ToString();
            gameOutput = output.Split(new[] { "\r\n"}, StringSplitOptions.None);
        }

        [Then(@"I should be asked for my name")]
        public void ThenIShouldBeAskedForMyName()
        {
            string expected = string.Format("What is your name?", Environment.NewLine);
            Assert.AreEqual(expected, gameOutput[0]);
        }

        [Given(@"I have already entered my name")]
        public void IHaveAlreadyEnteredMyName()
        {
            TestHelper.SetInput("Robert\n");
        }

        [Then(@"I expect to be asked what piece I would like to be")]
        public void IExpectToBeAskedWhatPieceIWouldLikeToBe()
        {
            string expected = "What piece would you like to be?";
            Assert.AreEqual(expected, gameOutput[1]);
        } 

    }
}
