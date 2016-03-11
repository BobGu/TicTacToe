using System;
using NUnit.Framework;
using TicTacToe.Games.OppositeMarkers;

namespace TicTacToe.Tests.Games.OppositeMarkers
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
