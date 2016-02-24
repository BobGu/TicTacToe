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
        public void Get_Marker()
        {
            TestHelper.SetInput("X\n");
            string marker = Prompt.GetPlayerMarker();
            Assert.AreEqual("X", marker);
        }

        [Test]
        public void Asks_For_Marker_Again_If_Invalid()
        {
            TestHelper.SetInput("P\nO\n");
            string marker = Prompt.GetPlayerMarker();
            Assert.AreNotEqual("P", marker);
            Assert.AreEqual("O", marker);
        }


        [Test]
        public void Get_Move()
        {
            TestHelper.SetInput("4\n");
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string move = Prompt.GetPlayerMove("Bob", spaces);
            Assert.AreEqual("4", move);
        }

        [Test]
        public void Get_Turn_Order()
        {
            TestHelper.SetInput("1\n");
            string turnOrder = Prompt.GetTurnOrder("Bob");
            Assert.AreEqual("1", turnOrder);
        }

        [Test]
        public void Does_Not_Accept_An_Invalid_Turn_Order()
        {
            TestHelper.SetInput("3\n2\n");
            string turnOrder = Prompt.GetTurnOrder("Robert");
            Assert.AreNotEqual("3", turnOrder);
            Assert.AreEqual("2", turnOrder);
        }

        [Test]
        public void Does_Not_Accept_Invalid_Move()
        {
            TestHelper.SetInput("fake move!\n2\n");
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string move = Prompt.GetPlayerMove("Robert", spaces);
        }


    }
}
