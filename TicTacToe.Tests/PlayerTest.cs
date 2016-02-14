using System;
using NUnit.Framework;
using TicTacToe;

namespace UnitTestProject1
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void CanAssignAndRetrieveAPlayersName()
        {
            string name = "Bob";
            Player player = new Player();
            player.AssignName(name);
            Assert.AreEqual("Bob", player.Name());
        }
    }
}
