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
        public void CanWinReturnsTrueIfCanWin()
        {
            string[] spaces = { "0", "1", "2", "3", "4", "5", "X", "X", "8" };
            Assert.IsTrue(easyStrategy.CanWin(spaces, "X"));
        }

        [Test]
        public void CanWinReturnsFalseIfCanNotWin()
        {
            string[] spaces = { "X", "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.IsFalse(easyStrategy.CanWin(spaces, "X"));
        }

        [Test]
        public void ReturnsTrueIfPossibleWinningSet()
        {
            string[] set = { "X", "X", "2" };
            Assert.IsTrue(easyStrategy.PossibleWinningSet(set, "X"));
        }

        [Test]
        public void ReturnsFalseIfNotAPossibleWinningSet()
        {
            string[] set = { "X", "X", "O" };
            Assert.IsFalse(easyStrategy.PossibleWinningSet(set, "X"));
        }

        [Test]
        public void ReturnsFalseIfNotAWinningRow()
        {
            string[] set = { "X", "1", "2" };
            Assert.IsFalse(easyStrategy.PossibleWinningSet(set, "X"));
        }

        [Test]
        public void ReturnsTrueIfTwoMarkersInSet()
        {
            string[] set = { "X", "X", "2" };
            Assert.IsTrue(easyStrategy.TwoMarkersInSet(set, "X"));
        }

        [Test]
        public void ReturnsFalseIfNotTwoMarkersInSet()
        {
            string[] set = { "X", "1", "O" };
            Assert.IsFalse(easyStrategy.TwoMarkersInSet(set, "O"));
        }

        [Test]
        public void FiltersTheSetForASpecifiedMarker()
        {
            string[] set = { "X", "7", "8" };
            Assert.AreEqual(new string[] { "X" }, easyStrategy.FilterSetForMarker(set, "X"));
        }

        [Test]
        public void FiltersTheSetForEmptySpaces()
        {
            string[] set = { "0", "1", "2" };
            Assert.AreEqual(set, easyStrategy.FilterSetForEmptySpaces(set));
        }
    }

}
