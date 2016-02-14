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
        public void CanAssignAndRetrieveAPlayerPiece()
        {
            Player player = new Player();
            player.AssignPiece("X");
            Assert.AreEqual("X", player.Piece());
        }
    }
}
