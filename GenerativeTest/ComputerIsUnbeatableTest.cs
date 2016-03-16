using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using TicTacToe.Games.RulesAndEvaluator;
using TicTacToe.Games.Players.Strategies;
using TicTacToe.Games.Players;


namespace TicTacToe.ComputerIsUnbeatable
{
    [TestFixture]
    public class ComputerIsUnbeatableTest
    {
        private Player computerPlayer;
        private List<string> gameResults = new List<string>();

        [SetUp]
        public void TestSetup()
        {
            computerPlayer = new Computer(new HardStrategy());

            computerPlayer.AssignMarker("O");

        }

        [Test]
        public void ComputerPlayerAlwaysWinsOrTies()
        {
            string[] spaces = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            GameResults(spaces);
            Console.WriteLine(gameResults.First());
            Assert.IsTrue(gameResults.All(gameResult => gameResult == "Computer has won or tied"));
        }

        private void GameResults(string[] spaces)
        {
            List<string[]> nextBoards = Minimax.FindNextBoards(spaces, "X");
            while (nextBoards.Count != 0)
            {
                foreach (string[] board in nextBoards)
                {
                    if (ComputerHasLostTheGame(board))
                    {
                        throw new Exception("The computer player has lost the game");
                    }
                    else if (GameIsTied(board))
                    {
                        gameResults.Add("Computer has won or tied");
                    }
                    else
                    {
                        int move = computerPlayer.Move(board);
                        board[move] = computerPlayer.marker;

                        if (ComputerHasWonTheGame(board) || GameIsTied(board))
                        {
                            gameResults.Add("Computer has won or tied");
                        }
                        else
                        {
                            GameResults(board);
                        }
                    }
                }
            }
        }

        private bool ComputerHasWinningSet(string[] set)
        {
            return set.All(space => space == "O");
        }

        private bool ComputerHasWonTheGame(string[] spaces)
        {
            string[][] rowsColumnsDiagonals = BoardEvaluator.RowsColumnsDiagonals(spaces);
            return rowsColumnsDiagonals.Any(set => ComputerHasWinningSet(set));
        }

        private bool ComputerHasLostTheGame(string[] spaces)
        {
            return !ComputerHasWonTheGame(spaces) && Rules.Over(spaces) && !GameIsTied(spaces);
        }

        private bool GameIsTied(string[] spaces)
        {
            return !Rules.Won(spaces) && Rules.Over(spaces);
        }

    }
}
