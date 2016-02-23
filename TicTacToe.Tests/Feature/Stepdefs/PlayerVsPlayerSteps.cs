using TechTalk.SpecFlow;
using TicTacToe;
using NUnit.Framework;
using System.IO;
using System;
using TicTacToe.Tests.TestHelper;

namespace Tests.Feature.Stepdefs
{
    [Binding]
    public class PlayerVsPlayerSteps
    {
        [Given(@"I have started the game")]
        public void GivenIHaveStartedTheGame()
        {
            Game game = new Game();
            game.Start();
        }
        
        [Given(@"I have entered my name correctly")]
        public void GivenIHaveEnteredMyNameCorrectly()
        {
            TestHelper.SetInput("Robert\n");
        }
        
        [When(@"I enter piece that isn't correct")]
        public void WhenIEnterPieceThatIsnTCorrect()
        {
            TestHelper.SetInput("P\n");
        }
        
        [Then(@"I should be asked for my name")]
        public void ThenThenIShouldBeAskedForMyName()
        {
           // string actual = TestHelper.SetOutput();
            //string expected = string.Format("What is your name?", Environment.NewLine);
            //Assert.AreEqual(expected, actual);
        }
        
        [Then(@"I should be asked which piece I would like to be")]
        public void ThenIShouldBeAskedWhichPieceIWouldLikeToBe()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
