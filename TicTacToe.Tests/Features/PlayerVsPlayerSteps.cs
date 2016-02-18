using System;
using TechTalk.SpecFlow;
using TicTacToe;
using System.IO;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [Binding]
    public class PlayerVsPlayerSteps
    {
        public string gameOutput;

        [Given(@"the game has started")]
        public void GivenTheGameHasStarted()
        {
            StringWriter sw = new StringWriter();
            Game game = new Game();
            Console.SetOut(sw);
            game.Start();
            string output = sw.ToString();
            gameOutput = Regex.Replace(output, "[^0-9a-zA-Z  ?]", "");
        }
        
        [Then(@"I should be asked for my name")]
        public void ThenIShouldBeAskedForMyName()
        {
            string expected = string.Format("What is your name?", Environment.NewLine);
            Assert.AreEqual(expected, gameOutput);
        }
    }
}
