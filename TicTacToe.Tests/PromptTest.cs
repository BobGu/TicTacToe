using System;
using System.IO;
using NUnit.Framework;
using TicTacToeTests.TestHelper;
using TicTacToe;

namespace TicTacToeTest
{
    [TestFixture]
    public class PromptTest
    {
        [SetUp]
        public void Capture_The_Output()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
        }
        [Test]
        public void Get_Name()
        {
            TestHelper.SetInput("Kirby\n");
            string name = Prompt.GetPlayerName();
            Assert.AreEqual("Kirby", name);
        }

        [Test]
        public void Get_Piece()
        {
            TestHelper.SetInput("X\n");
            string name = Prompt.GetPlayerPiece();
            Assert.AreEqual("X", name);
        }


        [Test]
        public void Get_Move()
        {
            TestHelper.SetInput("4\n");
            string move = Prompt.GetPlayerMove("Bob");
            Assert.AreEqual("4", move);
        }

        [Test]
        public void Get_Turn_Order()
        {
            TestHelper.SetInput("1\n");
            string turnOrder = Prompt.GetTurnOrder("Bob");
            Assert.AreEqual("1", turnOrder);
        }

    }
}
