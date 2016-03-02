﻿using System;
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
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5",
                                "X", "X", "8" };

            string[][] rowsColumnsDiagonals = new string[8][];

            rowsColumnsDiagonals[0] = new string[] { "0", "1", "2" };
            rowsColumnsDiagonals[1] = new string[] { "3", "4", "5" };
            rowsColumnsDiagonals[2] = new string[] { "X", "X", "8" };
            rowsColumnsDiagonals[3] = new string[] { "0", "3", "X" };
            rowsColumnsDiagonals[4] = new string[] { "1", "4", "X" };
            rowsColumnsDiagonals[5] = new string[] { "2", "5", "8" };
            rowsColumnsDiagonals[6] = new string[] { "0", "4", "8" };
            rowsColumnsDiagonals[7] = new string[] { "2", "4", "X" };

            Assert.IsTrue(easyStrategy.CanWin(rowsColumnsDiagonals, "X"));
        }

        [Test]
        public void CanWinReturnsFalseIfCanNotWin()
        {
            string[] spaces = { "X", "1", "2", "3", "4", "5", "6", "7", "8" };

            string[][] rowsColumnsDiagonals = new string[8][];

            rowsColumnsDiagonals[0] = new string[] { "X", "1", "2" };
            rowsColumnsDiagonals[1] = new string[] { "3", "4", "5" };
            rowsColumnsDiagonals[2] = new string[] { "6", "7", "8" };
            rowsColumnsDiagonals[3] = new string[] { "X", "3", "6" };
            rowsColumnsDiagonals[4] = new string[] { "1", "4", "7" };
            rowsColumnsDiagonals[5] = new string[] { "2", "5", "8" };
            rowsColumnsDiagonals[6] = new string[] { "X", "4", "8" };
            rowsColumnsDiagonals[7] = new string[] { "2", "4", "6" };

            Assert.IsFalse(easyStrategy.CanWin(rowsColumnsDiagonals, "X"));
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

        [Test]
        public void CanFindWinningSet()
        {
            string[] spaces = {"X", "X", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            string[] winningSet = { "X", "X", "2" };
            Assert.AreEqual(winningSet, easyStrategy.FindWinningSet(spaces, "X"));
        }
    }

}