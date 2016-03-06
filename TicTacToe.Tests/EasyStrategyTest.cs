using System;
using TicTacToe;
using NUnit.Framework;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class EasyStrategyTest
    {
        public EasyStrategy easyStrategy;

        [SetUp]
        public void ANewEasyStrategy()
        {
            easyStrategy = new EasyStrategy();
        }

        [Test]
        public void MakesARandomMove()
        {
            string[] spaces = { "X", "X", "O",
                                "O", "O", "O",
                                "6", "7", "X" };
            string randomMove = easyStrategy.RandomMove(spaces);
            Assert.IsTrue("7" == randomMove || "6" == randomMove);
        }

        [Test]
        public void BestMoveIsWinningMoveIfAvailable()
        {
            string[] spaces = { "X", "X", "O",
                                "O", "O", "5",
                                "6", "7", "X" };

            Assert.AreEqual(5, easyStrategy.BestMove(spaces, "O"));
        }

        [Test]
        public void ReturnsRandomMoveIfNoWinningMoveAvailable()
        {
            string[] spaces = {"X", "1", "O",
                               "O", "O", "X",
                               "X", "7", "8"};
            int bestMove = easyStrategy.BestMove(spaces, "X");
            Assert.IsTrue(1 == bestMove || 7 == bestMove || 8 == bestMove);
        }
    }

}
