using System;
using NUnit.Framework;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class HelperTest
    {
        [Test]
        public void ReturnsOppositeMarker()
        {
            Assert.AreEqual("O", Helper.OppositeMarker("X"));
        }
    }
}
