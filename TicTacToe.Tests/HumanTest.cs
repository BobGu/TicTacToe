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
            Assert.AreEqual("Bob", human.Name());
        }

        [Test]
        public void CanAssignAndRetrieveAPlayerPiece()
        {
            Human human = new Human();
            human.AssignPiece("X");
            Assert.AreEqual("X", human.Piece());
        }
    }
}
