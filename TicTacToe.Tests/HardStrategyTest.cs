using System;
using NUnit.Framework;
using TicTacToe;
using System.Collections.Generic;

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

        public void BestMoveReturnsTheWinningMove()
        {
            string[] spaces = {"O", "O", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            Assert.AreEqual(2, HardStrategy.BestMove(spaces, "O"));
        }

        public void BestMoveReturnsBlockingMove()
        {
            string[] spaces = {"0", "X", "2",
                               "O", "X", "5",
                               "6", "7", "8"};
            Assert.AreEqual(7, HardStrategy.BestMove(spaces, "O"));
        }

        public void MinimaxReturnsNegativeScoreIfOpponentCanWin()
        {
            string[] spaces = {"O", "O", "X",
                              "X", "X", "5",
                             "O", "O", "8" };
            int bestValue = HardStrategy.Minimax(spaces, "O", 3, true);
            Assert.AreEqual(-20, bestValue);
        }

        public void MinimaxReturnsPositiveScoreIfWinningBoard()
        {
            string[] spaces = {"O", "O", "O",
                               "3", "4", "5",
                               "6", "7", "8"};
            int bestValue = HardStrategy.Minimax(spaces, "O", 7, true);
            Assert.AreEqual(70, bestValue);
        }

        public void MinimaxReturnsPostiveScoreIfInFavorablePosition()
        {
            string[] spaces = {"O", "1", "O",
                               "X", "X", "O",
                               "6", "7", "8" };
            int bestValue = HardStrategy.Minimax(spaces, "O", 5, true);
            Assert.AreEqual(40, bestValue);
        }

        public void MinimaxReturnZeroScoreIfBestItCanDoIsTie()
        {
            string[] spaces = {"O", "X", "O",
                               "X", "X", "5",
                               "X", "O", "8"};
            int bestValue = HardStrategy.Minimax(spaces, "X", 3, false);
            Assert.AreEqual(0, bestValue);
        }

        [Test]
        public void ReturnsImmediateChildrenOfABoard()
        {
            List<string[]> children = new List<string[]>();

            string[] spaces = {"X", "O", "X",
                               "O", "X", "O",
                               "6", "X", "8"};
            string[] childOne = {"X", "O", "X",
                                 "O", "X", "O",
                                 "O", "X", "8"};
            string[] childTwo= {"X", "O", "X",
                                "O", "X", "O",
                                "P", "X", "O"};

            children.Add(childOne);
            children.Add(childTwo);

            Assert.AreEqual(children, HardStrategy.FindChildren(spaces, "O"));

                                     
        }



    }
}
