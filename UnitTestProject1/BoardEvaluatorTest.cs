using System;
using NUnit.Framework;
using TicTacToe;

namespace UnitTestProject1
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

    }
}
