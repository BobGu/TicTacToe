using System;
using NUnit.Framework;
using TicTacToe;
using System.Collections.Generic;

namespace TicTacToe.Tests 
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
        public void CanScoreAWinningBoard()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8"};
            Assert.AreEqual(10, hardStrategy.Score(spaces));
        }

        [Test]
        public void CanScoreATiedBoard()
        {
            string[] spaces = {"O", "O", "X",
                               "X", "X", "O",
                               "O", "X", "X"};
            Assert.AreEqual(0, hardStrategy.Score(spaces));
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
        public void PairsMovesWithTheirScores()
        {
            string[] spaces = {"O", "X", "O",
                               "X", "X", "5",
                               "X", "O", "8"};
            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(5, 0);
            expected.Add(8, -10);

            CollectionAssert.AreEquivalent(expected, hardStrategy.ScoresByMove(spaces, "O"));
        }

        [Test]
        public void MinimaxReturnsNegativeScoreIfOpponentCanWin()
        {
            string[] spaces = {"O", "O", "X",
                              "X", "X", "5",
                             "O", "O", "8" };
            int bestValue = hardStrategy.Minimax(spaces, "O", 3, true);
            Assert.AreEqual(-20, bestValue);
        }

        [Test]
        public void MinimaxReturnsPositiveScoreIfWinningBoard()
        {
            string[] spaces = {"O", "O", "O",
                               "3", "4", "5",
                               "6", "7", "8"};
            int bestValue = hardStrategy.Minimax(spaces, "O", 7, true);
            Assert.AreEqual(70, bestValue);
        }

        [Test]
        public void MinimaxReturnsPostiveScoreIfInFavorablePosition()
        {
            string[] spaces = {"O", "1", "O",
                               "X", "X", "O",
                               "6", "7", "8" };
            int bestValue = hardStrategy.Minimax(spaces, "O", 5, true);
            Assert.AreEqual(30, bestValue);
        }

        [Test]
        public void MinimaxReturnZeroScoreIfBestItCanDoIsTie()
        {
            string[] spaces = {"O", "X", "O",
                               "X", "X", "5",
                               "X", "O", "8"};
            int bestValue = hardStrategy.Minimax(spaces, "X", 3, false);
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
            string[] childTwo = {"X", "O", "X",
                                "O", "X", "O",
                                "6", "X", "O"};

            children.Add(childOne);
            children.Add(childTwo);

            Assert.AreEqual(children, hardStrategy.FindChildren(spaces, "O"));
        }

        [Test]
        public void CanFindTheImmediateChildren()
        {
            string[] spaces = {"0", "1", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            List<string[]> children = hardStrategy.FindChildren(spaces, "X");

            foreach(string space in spaces)
            {
                int index = Int32.Parse(space);
                string[] child = children[index];

                Assert.AreEqual("X", child[index]);
            }
        }
        

    }
}
