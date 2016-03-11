using System;
using NUnit.Framework;
using TicTacToe.Games.Players.Strategies;
using System.Diagnostics;

namespace TicTacToe.Tests.Games.Players.Strategies
{
    [TestFixture]
    public class HardStrategyTest
    {
        HardStrategy hardStrategy;
        
        [SetUp]
        public void NewHardStrategyObjectIsCreated()
        {
            hardStrategy = new HardStrategy();
        }

        [Test]
        public void BestMoveReturnsTheWinningMove()
        {
            string[] spaces = {"O", "O", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            Assert.AreEqual(2, hardStrategy.BestMove(spaces, "O"));
        }

        [Test]
        public void BestMoveReturnsBlockingMove()
        {
            string[] spaces = {"0", "X", "2",
                               "O", "X", "5",
                               "6", "7", "8"};
            Assert.AreEqual(7, hardStrategy.BestMove(spaces, "O"));
        }
        [Test]
        public void BestMoveEnsuresATie()
        {
            string[] spaces = {"O", "X", "O",
                               "X", "X", "5",
                               "X", "O", "8"};
            Assert.AreEqual(5, hardStrategy.BestMove(spaces, "O"));
        }

        [Test]
        public void CanFindBestMoveUnderASecondWhenMovingFirst()
        {
            var watch = new Stopwatch();
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

            watch.Start();
            hardStrategy.BestMove(spaces, "X");
            watch.Stop();

            Assert.IsTrue(watch.Elapsed.TotalMilliseconds < 1000);
        }

    }
}
