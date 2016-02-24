using System;
using System.Linq;
using TechTalk.SpecFlow;
using TicTacToe;
using System.IO;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TicTacToeTests.TestHelper;

namespace UnitTestProject1
{
    [Binding]
    public class PlayerVsPlayerSteps : Steps
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

        public void EnterInputRunGameSetupCaptureOutput()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.SetUp();
            CaptureOutput(sw);
        }
        public void EnterInputRunGameStartCaptureOutput()
        {
            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.Start();
            CaptureOutput(sw);
        }

        public string EnterInputStartGameBoardOutput()
        {

            TestHelper.SetInput(gameInput);
            StringWriter sw = SetOutputToStringWriter();
            game.Start();
            return sw.ToString();
        }

        public void BoardSetupForAPlayerOneWin()
        {
            gameInput = gameInput + "0\n3\n1\n4\n";
        }

        public void PlayerOneMakeWinningMove()
        {
            gameInput = gameInput + "2\n";
        }

        public void PlayersMoveTillGameIsTied()
        {
            gameInput = gameInput + "0\n2\n1\n3\n5\n4\n6\n7\n8\n";
        }


        [Given(@"the game has started")]
        public void GivenTheGameHasStarted()
        {
            FlushStandardOut();
            FlushStandardIn();
            game = new Game();
        }

        [Given(@"I have already entered my marker")]
        public void AndIEnterAllPlayerInfo()
        {
            gameInput = gameInput + "X\n";
        }

        [Given(@"I enter a turn order")]
        public void IEnterATurnOrder()
        {
            gameInput = gameInput + "1\n";
        }

        [Then(@"I should have been asked for my name")]
        public void ThenIShouldBeAskedForMyName()
        {
            EnterInputRunGameSetupCaptureOutput();
            string expected = string.Format("What is your name?", Environment.NewLine);
            Assert.AreEqual(expected, gameOutput[0]);
        }

        [Given(@"I have already entered my name")]
        public void IHaveAlreadyEnteredMyName()
        {
            gameInput = "Robert\n";
        }

        [Given(@"I enter a second players name")]
        public void IEnterASecondPlayersName()
        {
            gameInput = gameInput + "John\n";
        }

	    [Then(@"I should have been asked what marker I would like to be")]
        public void IExpectToBeAskedWhatPieceIWouldLikeToBe()
        {
            EnterInputRunGameSetupCaptureOutput();
            string expected = "What piece would you like to be, X or O?";
            Assert.AreEqual(expected, gameOutput[1]);
        }

        [Given(@"I enter a marker that is not X or O")]
        public void IEnterAMarkerThatIsNotXorO()
        {
            gameInput = gameInput + "ABC123\n";
        }

        [Then(@"I am told my marker was invalid")]
        public void IAmToldMyMarkerWasInvalid()
        {
            
            EnterInputRunGameSetupCaptureOutput();
            string expected = "ABC123 is not a valid input";
            Assert.AreEqual(expected, gameOutput[2]);
        }

        [Then(@"I am asked again which marker I would like to be")]
        public void IAmAskedAgainWhichMarkerIWouldLikeToBe()
        {
            string expected = "What piece would you like to be, X or O?";
            Assert.AreEqual(expected, gameOutput[3]);
        }

        [Given(@"I enter a valid marker")]
        public void IEnterAValidMarker()
        {
            gameInput = gameInput + "X\n";
        }

        [Given(@"the first player has entered their info")]
        public void TheFirstPayerHasEnteredTheirInfo()
        {
            gameInput = "Robert\nX\n";
        }

        [Then(@"the second player should have been asked for their name")]
        public void TheSecondPlayerShouldBeAskedForTheirName()
        {
            EnterInputRunGameSetupCaptureOutput();
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
            EnterInputRunGameSetupCaptureOutput();
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
            EnterInputRunGameStartCaptureOutput();
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
            EnterInputRunGameStartCaptureOutput();
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

        [Then(@"I expect the first board to be an empty board")]
        public void IExpectToSeeAnEmptyBoard()
        {
            string output = EnterInputStartGameBoardOutput();
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
            StringAssert.Contains(expected, output);

        }

        [Given(@"players have filled the rest of the board")]
        public void PlayersHaveMadeTheirMoves()
        {
            gameInput = gameInput + "1\n2\n3\n5\n6\n7\n8\n";
        }

        [Given(@"players have made the necessary moves")]
        public void PlayersHaveMadeTheNecessaryMoves()
        {
            gameInput = gameInput + "0\n1\n2\n3\n4\n5\n6\n7\n8\n";
        }

        [Given(@"I choose the center space")]
        public void IChooseTheCenterSpace()
        {
            gameInput = gameInput + "4\n";
        }

        [Then(@"I expect to see that space marked")]
        public void IExpectToSeeThatSpaceMarked()
        {
            string output = EnterInputStartGameBoardOutput();
            string expected =
                @"     |     |     |
                   0   |  1  |  2  |
                  _____|_____|_____|
                       |     |     |
                   3   |  X  |  5  |
                  _____|_____|_____|
                       |     |     |
                   6   |  7  |  8  |
                  _____|_____|_____|";
            StringAssert.Contains(expected, output);
        }

        [Given(@"second player chooses the top left space")]
        public void SecondPlayerChoosesTheTopLeftSpace()
        {
            gameInput = gameInput + "0\n";
        }

        [Then(@"I expect to see the top left space filled with the correct marker")]
        public void IExpectToSeeTheTopLeftSpaceFilledWithTheCorrectMarker()
        {
            string output = EnterInputStartGameBoardOutput();
            string expected =
                @"     |     |     |
                   O   |  1  |  2  |
                  _____|_____|_____|
                       |     |     |
                   3   |  X  |  5  |
                  _____|_____|_____|
                       |     |     |
                   6   |  7  |  8  |
                  _____|_____|_____|";
            StringAssert.Contains(expected, output);
        }

        [Given(@"board is setup so player one can win")]
        public void BoardIsSetupSoPlayerOneCanWin()
        {
            BoardSetupForAPlayerOneWin();
        }

        [Given(@"player one makes a winning move")]
        public void PlayeOneMakesAWinningMove()
        {
            PlayerOneMakeWinningMove();
        }

	    [Then(@"I expect to see a message congratualting player one")]
        public void IExpectToSeeAMessageCongratulatingPlayerOne()
        {
            EnterInputRunGameStartCaptureOutput();
            string expect = "Robert has won the game";
            int lastOutputLength= gameOutput.Count();
            string lastOutput = gameOutput[lastOutputLength - 2];
            Assert.AreEqual(expect, lastOutput);
        }

        [Given(@"players move so that they are tied")]
        public void PlayersMoveSoThatTheyAreTied()
        {
            PlayersMoveTillGameIsTied();
        }

        [Then(@"I expect to see a message saying the game is tied")]
        public void IExpectToSeeAMessageSayingTheGameIsTied()
        {
            EnterInputRunGameStartCaptureOutput();
            string expect = "The game is a tie";
            int lastOutputLength = gameOutput.Count();
            string lastOutput = gameOutput[lastOutputLength - 2];
            Assert.AreEqual(expect, lastOutput);
        }

    }
        
}
