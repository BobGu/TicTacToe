using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class MinimaxTest
    {
        [Test]
        public void MinimaxReturnsNegativeScoreIfOpponentCanWin()
        {
            string[] spaces = {"O", "O", "X",
                              "X", "X", "5",
                             "O", "O", "8" };
            int bestValue = Minimax.MinOrMaxScore(spaces, "O", 3, true);
            Assert.AreEqual(-20, bestValue);
        }

        [Test]
        public void MinimaxReturnsPositiveScoreIfWinningBoard()
        {
            string[] spaces = {"O", "O", "O",
                               "3", "4", "5",
                               "6", "7", "8"};
            int bestValue = Minimax.MinOrMaxScore(spaces, "O", 7, true);
            Assert.AreEqual(70, bestValue);
        }

        [Test]
        public void MinimaxReturnsPostiveScoreIfInFavorablePosition()
        {
            string[] spaces = {"O", "1", "O",
                               "X", "X", "O",
                               "6", "7", "8" };
            int bestValue = Minimax.MinOrMaxScore(spaces, "O", 5, true);
            Assert.AreEqual(30, bestValue);
        }

        [Test]
        public void MinimaxReturnZeroScoreIfBestItCanDoIsTie()
        {
            string[] spaces = {"O", "X", "O",
                               "X", "X", "5",
                               "X", "O", "8"};
            int bestValue = Minimax.MinOrMaxScore(spaces, "X", 3, false);
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

            Assert.AreEqual(children, Minimax.FindNextBoards(spaces, "O"));
        }

        [Test]
        public void CanFindTheImmediateChildren()
        {
            string[] spaces = {"0", "1", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            List<string[]> children = Minimax.FindNextBoards(spaces, "X");

            foreach(string space in spaces)
            {
                int index = Int32.Parse(space);
                string[] child = children[index];

                Assert.AreEqual("X", child[index]);
            }
        }
    }
}
