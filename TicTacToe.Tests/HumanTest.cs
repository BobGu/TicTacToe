using System;
using NUnit.Framework;
using TicTacToe;
using TicTacToe.Tests.TestHelper;

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

        [Test]
        public void CanMakeAMove()
        {
            Human human = new Human();
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8"};
            TestHelper.SetInput("4");
            Assert.AreEqual(4, human.Move(spaces, "Robert", "O"));
        }
    }
}
