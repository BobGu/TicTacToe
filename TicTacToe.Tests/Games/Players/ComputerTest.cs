﻿using System;
using NUnit.Framework;
using System.IO;
using TicTacToe.Games.Players;
using TicTacToe.Games.Players.Strategies;

namespace TicTacToe.Tests.Games.Players 
{
    [TestFixture]
    public class ComputerTest
    {

        [Test]
        public void CanMakeAMove()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            IComputerStrategy hardStrategy = new HardStrategy();
            Computer computer = new Computer(hardStrategy);
            computer.AssignMarker("X");
            string[] spaces = { "X", "X", "2", "3", "4", "5", "6", "7", "8" };
            Assert.AreEqual(2, computer.Move(spaces));
        }
    }
}
