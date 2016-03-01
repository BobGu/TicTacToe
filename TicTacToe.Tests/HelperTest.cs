using System;
using NUnit.Framework;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class HelperTest
    {
        [Test]
        public void ReturnsOppositeMarkerj()
        {
            Assert.AreEqual("O", Helper.OppositeMarker("X"));
        }
    }
}
