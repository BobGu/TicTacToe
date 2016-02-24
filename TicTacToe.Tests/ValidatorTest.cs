using System;
using TicTacToe;
using NUnit.Framework;

namespace TicTacToe.Tests 
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
            Assert.IsTrue(Validator.Move(0, spaces));
            Assert.IsFalse(Validator.Move(1, spaces));
        }
    }
}
