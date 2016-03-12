using System;
using NUnit.Framework;
using TicTacToe.Games.RulesAndEvaluator;

namespace TicTacToe.Tests.Games.RulesAndEvaluator
{
    [TestFixture]
    public class BoardEvaluatorTest
    {
        [Test]
        public void SpaceThatReturnMarkersAreNotEmpty()
        {
            string space = "X";
            bool result = BoardEvaluator.IsAnEmptySpace(space);
            Assert.IsFalse(result);
        }

        [Test]
        public void SpaceThatReturnsANonMarkerIsNotEmpty()
        {
            string space = "4";
            bool result = BoardEvaluator.IsAnEmptySpace(space);
            Assert.IsTrue(result);
        }

        [Test]
        public void ChecksIfAllSpacesAreNotEmpty()
        {
            string[] spaces = { "X", "O", "X", "X", "X", "X", "X", "X", "X" };
            bool result = BoardEvaluator.AllSpacesNotEmpty(spaces);
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfAllSpacesAreNotEmpty()
        {
            string[] spaces = { "X", "X", "X", "X", "X", "X", "X", "X", "8" };
            bool result = BoardEvaluator.AllSpacesNotEmpty(spaces);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanFindRowsColumnsAndDiagonals()
        {
            string[] spaces = {"0", "1", "2",
                               "3", "4", "5",
                               "6", "7", "8"};
            string[][] rowsColumnsDiagonals = new string[8][];
            rowsColumnsDiagonals[0] = new string[] { "0", "1", "2" };
            rowsColumnsDiagonals[1] = new string[] { "3", "4", "5" };
            rowsColumnsDiagonals[2] = new string[] { "6", "7", "8" };
            rowsColumnsDiagonals[3] = new string[] { "0", "3", "6" };
            rowsColumnsDiagonals[4] = new string[] { "1", "4", "7" };
            rowsColumnsDiagonals[5] = new string[] { "2", "5", "8" };
            rowsColumnsDiagonals[6] = new string[] { "0", "4", "8" };
            rowsColumnsDiagonals[7] = new string[] { "2", "4", "6" };
            CollectionAssert.AreEqual(rowsColumnsDiagonals, BoardEvaluator.RowsColumnsDiagonals(spaces));
        }

        [Test]
        public void CanFindRowsColumnsAndDiagonalsOnAnyBoardSize()
        {
            string[] spaces = {"0", "1", "2", "3",
                               "4", "5", "6", "7",
                               "8", "9", "10", "11",
                               "12", "13", "14", "15"};

            string[][] rowsColumnsDiagonals = new String[10][];
            rowsColumnsDiagonals[0] = new string[] { "0", "1", "2", "3" };
            rowsColumnsDiagonals[1] = new string[] { "4", "5", "6", "7" };
            rowsColumnsDiagonals[2] = new string[] { "8", "9", "10", "11" };
            rowsColumnsDiagonals[3] = new string[] { "12", "13", "14", "15" };
            rowsColumnsDiagonals[4] = new string[] { "0", "4", "8", "12" };
            rowsColumnsDiagonals[5] = new string[] { "1", "5", "9", "13" };
            rowsColumnsDiagonals[6] = new string[] { "2", "6", "10", "14" };
            rowsColumnsDiagonals[7] = new string[] { "3", "7", "11", "15" };
            rowsColumnsDiagonals[8] = new string[] { "0", "5", "10", "15" };
            rowsColumnsDiagonals[9] = new string[] { "3", "6", "9", "12" };

            CollectionAssert.AreEqual(rowsColumnsDiagonals, BoardEvaluator.RowsColumnsDiagonals(spaces));
        }

        [Test]
        public void ReturnTrueIfAnySetsAreTheSame()
        {
            string[] spaces = { "X", "X", "X", "3", "4", "5", "6", "7", "8" };
            Assert.IsTrue(BoardEvaluator.AnySetsTheSame(spaces));
        }

        [Test]
        public void ReturnFalseIfAnySetsAreTheSame()
        {
            string[] spaces = { "X", "X", "2", "3", "4", "5", "6", "7", "8" };
            Assert.IsFalse(BoardEvaluator.AnySetsTheSame(spaces));
        }

        [Test]
        public void ReturnAvailableSpaces()
        {
            string[] spaces = { "X", "X", "2", "3", "4", "5", "6", "7", "8" };
            string[] expected = { "2", "3", "4", "5", "6", "7", "8" };
            Assert.AreEqual(expected, BoardEvaluator.AvailableSpaces(spaces));
        }
    }
}
