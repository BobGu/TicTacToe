using System;
using System.IO;
using TechTalk.SpecFlow;
using TicTacToe.Tests.TestHelper;
using TicTacToe.Games;
using NUnit.Framework;


namespace UnitTestProject1.Features
{
    [Binding]
    public class PlayerVsComputerSteps
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

        public void CaptureOutput(StringWriter sw)
        {
            string output = sw.ToString();
            gameOutput = output.Split(new[] { "\r\n" }, StringSplitOptions.None);
        }

        public void EnterInputRunGameStartCaptureOutput()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.Start();
            CaptureOutput(sw);
        }

        [Given(@"the game has already started")]
        public void GivenTheGameHasAlreadyStarted()
        {
            FlushStandardOut();
            FlushStandardIn();
            game = new Game();
        }

        [Given(@"I choose a human vs computer game")]
        public void GivenIChooseAHumanVsComputerGame()
        {
            gameInput = "hc\nH\n";
        }
        
        [Given(@"the first player entered all their info")]
        public void GivenTheFirstPlayerEnteredAllTheirInfo()
        {
            gameInput = gameInput + "Robert\nX\n";
        }
        
        [Given(@"player one chooses to go last")]
        public void GivenPlayerOneChoosesToGoLast()
        {
            gameInput = gameInput + "2\n";
        }

        [Given(@"all other info is entered for the game")]
        public void GivenAllOtherInfoIsEnteredForTheGame()
        {
            gameInput = gameInput + "0\n1\n2\n3\n4\n5\n6\n7\n8\n";
        }

        [Then(@"I expect the computer player to be asked for their name")]
        public void ThenIExpectTheComputerPlayerToBeAskedForTheirName()
        {
            EnterInputRunGameStartCaptureOutput();
            string expect = "Where would you like to move Johnny 5?";
            StringAssert.Contains(expect, gameOutput[15]);
        }
    }
}
