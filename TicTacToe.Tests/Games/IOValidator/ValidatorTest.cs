using System;
using TicTacToe.Games.IOValidator;
using NUnit.Framework;

namespace TicTacToe.Tests.Games.IOValidator
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test]
        public void ReturnsTrueIfMarkerIsValid()
        {
            Assert.IsTrue(Validator.Marker("X"));
        }

        [Test]
        public void ReturnsFalseIfMarkerIsNotValid()
        {
            Assert.IsFalse(Validator.Marker("P"));
        }

        [Test]
        public void ReturnsTrueIfTurnOrderIsValid()
        {
            Assert.IsTrue(Validator.TurnOrder("1"));
            Assert.IsTrue(Validator.TurnOrder("2"));
        }

        [Test]
        public void ReturnFalseIfTurnOrderIsNotValid()
        {
            Assert.IsFalse(Validator.TurnOrder("3"));
            Assert.IsFalse(Validator.TurnOrder("Q"));
        }

        [Test]
        public void ReturnsTrueIfSpaceIsAvailable()
        {
            string[] spaces = { "0", "X", "2", "3", "O", "5", "6", "7", "8" };
            Assert.IsTrue(Validator.Move("0", spaces));
        }

        [Test]
        public void ReturnsFalseIfSpaceIsNotAvailable()
        {
            string[] spaces = { "0", "X", "2", "3", "O", "5", "6", "7", "8" };
            Assert.IsFalse(Validator.Move("1", spaces));
        }

        [Test]
        public void ReturnFalseIfNotAnActualSpace()
        {
            string[] spaces = { "0", "X", "2", "3", "O", "5", "6", "7", "8" };
            Assert.IsFalse(Validator.Move("9", spaces));
        }

        [Test]
        public void ReturnsTrueIfAcceptableGameMode()
        {
            Assert.IsTrue(Validator.GameMode("hc"));
        }

        [Test]
        public void ReturnsFalseIfNotValidGameMode()
        {
            Assert.IsFalse(Validator.GameMode("pp"));
        }

        [Test]
        public void ReturnsTrueForHumanVsHumanGameMode()
        {
            Assert.IsTrue(Validator.GameMode("hh"));
        }

        [Test]
        public void ReturnsTrueIfValidRegardlessOfCapitalzation()
        {
            Assert.IsTrue(Validator.GameMode("HC"));
        }

        [Test]
        public void ReturnsTrueIfValidStrategyLevel()
        {
            Assert.IsTrue(Validator.StrategyLevel("E"));
        }

        [Test]
        public void ReturnsTrueIfValidBoardDimmensions()
        {
            Assert.IsTrue(Validator.BoardDimmensions("3"));
        }

        [Test]
        public void ReturnFalseIfNotValidBoardDimmensions()
        {
            Assert.IsFalse(Validator.BoardDimmensions("5"));
        }

    }
}
