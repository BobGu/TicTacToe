using System;
using NUnit.Framework;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class ComputerTest
    {
        [Test]
        public void CanBeSetToADifficultStrategy()
        {
            IComputerDifficulty hardStrategy = new HardStrategy();
            Computer computer = new Computer(hardStrategy);
            Assert.AreEqual(hardStrategy, computer.strategy);
        }

        [Test]
        public void CanMakeAMove()
        {
            IComputerDifficulty hardStrategy = new HardStrategy();
            Computer computer = new Computer(hardStrategy);
            string[] spaces = { "X", "X", "2", "3", "4", "5", "6", "7", "8" };
            Assert.AreEqual(2, computer.Move(spaces, "X"));
        }
    }
}
