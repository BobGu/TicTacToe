using System;
using TicTacToe.Games.Players.Strategies;
using NUnit.Framework;


namespace TicTacToe.Tests.Players.Strategies
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
        public void BestMoveIsAWinningMooveIfAvaialble()
        {
            string[] spaces = {"X", "X", "2", "X",
                               "4", "5", "6", "7",
                               "8", "9", "10", "11",
                               "12", "13", "14", "15"};

            Assert.AreEqual(2, easyStrategy.BestMove(spaces, "X"));
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
