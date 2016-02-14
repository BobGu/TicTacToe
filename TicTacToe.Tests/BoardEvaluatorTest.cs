using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class BoardEvaluatorTest
    {
        [Test]
        public void SpaceThatReturnMarkersAreNotEmpty()
        {
            string space = "X";
            bool result = BoardEvaluator.IsNotAnEmptySpace(space);
            Assert.IsTrue(result);
        }

        [Test]
        public void SpaceThatReturnsANonMarkerIsNotEmpty()
        {
            string space = "4";
            bool result = BoardEvaluator.IsNotAnEmptySpace(space);
            Assert.IsFalse(result);
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
        public void ChecksToSeeIfAllSpacesAreTheSame()
        {
            string[] threeInARow = { "X", "X", "X" } ;
            bool allTheSame = BoardEvaluator.AllSpacesTheSame(threeInARow);
            Assert.IsTrue(allTheSame);

            string[] twoInARow = {"X", "X", "2"};
            bool almostAllTheSame = BoardEvaluator.AllSpacesTheSame(twoInARow);
            Assert.IsFalse(almostAllTheSame);
        }

        [Test]
        public void CanFindTheRows()
        {
            string[] spaces = { "X", "O", "X", "3", "4", "5", "6", "7", "8" };
            string[][] rows = new string[3][];
            rows[0] = new string[] { "X", "O", "X" };
            rows[1] = new string[] { "3", "4", "5" };
            rows[2] = new string[] { "6", "7", "8" };
            CollectionAssert.AreEqual(rows, BoardEvaluator.Rows(spaces));
        }

        [Test]
        public void CanFindTheColumns()
        {
            string[] spaces = { "X", "O", "X", "3", "4", "5", "6", "7", "8" };
            string[][] columns = new string[3][];
            columns[0] = new string[] { "X", "3", "6" };
            columns[1] = new string[] { "O", "4", "7" };
            columns[2] = new string[] { "X", "5", "8" };
            CollectionAssert.AreEqual(columns, BoardEvaluator.Columns(spaces));
        }

        [Test]
        public void CanFindTheDiagonals()
        {
            string[] spaces = { "X", "O", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            string[][] diagonals = new string[2][];
            diagonals[0] = new string[] { "X", "4", "8" };
            diagonals[1] = new string[] { "X", "4", "6" };
            CollectionAssert.AreEqual(diagonals, BoardEvaluator.Diagonals(spaces));
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
    }
}
