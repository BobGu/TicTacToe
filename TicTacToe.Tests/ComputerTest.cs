using System;
using NUnit.Framework;
using System.IO;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class ComputerTest
    {

        [Test]
        public void CanMakeAMove()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            IComputerDifficulty hardStrategy = new HardStrategy();
            Computer computer = new Computer(hardStrategy);
            string[] spaces = { "X", "X", "2", "3", "4", "5", "6", "7", "8" };
            Assert.AreEqual(2, computer.Move(spaces, "Robert", "X"));
        }
    }
}
