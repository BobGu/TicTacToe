using System;
using NUnit.Framework;
using TicTacToe;


namespace TicTacToe.Tests 
{
    [TestFixture]
    public class RulesTest
    {
        [Test]
        public void GameIsOverWhenBoardIsFilledAndNotWon()
        {
            string[] spaces = { "X", "O", "X",
                                "X", "X", "O",
                                "O", "X", "O" };
            Assert.IsTrue(Rules.Over(spaces));
        }

        [Test]
        public void GameIsNotOverWhenBoardIsEmpty()
        {
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsFalse(Rules.Over(spaces));
        }

        [Test]
        public void GameIsOverWhenGameIsWon()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8"};
            Assert.IsTrue(Rules.Over(spaces));
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledTopRow()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsTrue(Rules.Won(spaces));
        }

        [Test]
        public void GameIsNotWonTopRowIsFilledWithMixedMarkers()
        {
            string[] spaces = { "X", "O", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsFalse(Rules.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenSecondRowIsFilledWithOneMarker()
        {
            string[] spaces = { "0", "1", "2", 
                                "X", "X", "X", 
                                "6", "7", "8" };
            Assert.IsTrue(Rules.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenThirdRowIsFilledWithOneMarker()
        {
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5", 
                                "X", "X", "X" };
            Assert.IsTrue(Rules.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenFirstColumnIsFilledWithOneMarker()
        {
            string[] spaces = { "O", "1", "2",
                                "O", "4", "5",
                                "O", "7", "8"};
            Assert.IsTrue(Rules.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenSecondColumnIsFilledWithOneMarker()
        {
            string[] spaces = {"0", "X", "2",
                               "3", "X", "5",
                               "6", "X", "8"};
            Assert.IsTrue(Rules.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenThirdColumnIsFilledWithOneMarker()
        {
            string[] spaces = {"0", "1", "X",
                               "3", "4", "X",
                               "6", "7", "X"};
            Assert.IsTrue(Rules.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenFirstDigonalIsFilledWithOneMarker()
        {
            string[] spaces = {"X", "1", "2",
                               "3", "X", "5",
                               "6", "7", "X"};
            Assert.IsTrue(Rules.Won(spaces)); 
        }

        [Test]
        public void GameIsWonWhenSecondDigonalIsFilledWithOneMarker()
        {
            string[] spaces = {"0", "1", "X",
                               "3", "X", "5",
                               "X", "7", "8"};
            Assert.IsTrue(Rules.Won(spaces));
        }
    }
}
