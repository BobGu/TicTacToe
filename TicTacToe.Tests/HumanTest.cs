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
            Human human = new Human();
            human.AssignName("Bob");
            Assert.AreEqual("Bob", human.name);
        }

        [Test]
        public void CanAssignAndRetrieveAPlayerPiece()
        {
            Human human = new Human();
            human.AssignMarker("X");
            Assert.AreEqual("X", human.marker);
        }
    }
}
