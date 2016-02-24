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
    }
}
