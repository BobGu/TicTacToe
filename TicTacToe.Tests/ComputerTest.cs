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
    }
}
