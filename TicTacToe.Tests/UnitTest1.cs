using System;
using NUnit.Framework;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class OppositeMarkerTest 
    {
        [Test]
        public void ReturnsTheOppositeMarker()
        {
            Assert.AreEqual("O", OppositeMarker.Marker("X"));
        }
    }
}
