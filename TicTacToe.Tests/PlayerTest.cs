using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void CanAssignAndRetrieveAPlayersName()
        {
            Player player = new Player();
            player.AssignName("Bob");
            Assert.AreEqual("Bob", player.Name());
        }

        [Test]
        public void CanAssignAndRetrieveAPlayerMarker()
        {
            Player player = new Player();
            player.AssignMarker("X");
            Assert.AreEqual("X", player.Marker());
        }
    }
}
