using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe.Tests 
{
    [TestFixture]
    public class HardStrategyTest
    {
        [Test]
        public void CanScoreAWinningBoard()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8"};
            Assert.AreEqual(10, HardStrategy.Score(spaces));
        }

        [Test]
        public void CanScoreATiedBoard()
        {
            string[] spaces = {"O", "O", "X",
                               "X", "X", "O",
                               "O", "X", "X"};
            Assert.AreEqual(0, HardStrategy.Score(spaces));
        }

        [Test]
        public void BestMoveReturnsTheWinningMove()
        {
            string[] spaces = {"O", "O", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            Assert.AreEqual(2, HardStrategy.BestMove(spaces, "O"));
        }

        [Test]
        public void MinimaxReturnsHighestScore()
        {
            string[] spaces = {"O", "O", "X",
                              "X", "X", "5",
                             "O", "O", "8" };
            int bestValue = HardStrategy.Minimax(spaces, "O", true);
            Assert.AreEqual(-10, bestValue);
        }

        [Test]
        public void MinimaxReturnsPositiveScoreIfWinningBoard()
        {
            string[] spaces = {"O", "O", "O",
                               "3", "4", "5",
                               "6", "7", "8"};
            int bestValue = HardStrategy.Minimax(spaces, "O", true);
            Assert.AreEqual(10, bestValue);
        }

        [Test]
        public void MinimaxReturnsPositiveScoreIfInFavorablePosition()
        {
            string[] spaces = {"O", "1", "O",
                               "X", "4", "O",
                               "X", "7", "8" };
            int bestValue = HardStrategy.Minimax(spaces, "O", true);
            Assert.AreEqual(10, bestValue);
        }

        [Test]
        public void MinimaxReturnZeroScoreIfBestItCanDoIsTie()
        {
            string[] spaces = {"O", "X", "O",
                               "X", "X", "5",
                               "X", "O", "8"};
            int bestValue = HardStrategy.Minimax(spaces, "X", false);
            Assert.AreEqual(0, bestValue);
        }


    }
}
