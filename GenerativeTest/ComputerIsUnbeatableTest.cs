using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using TicTacToe.Games.RulesAndEvaluator;
using TicTacToe.Games.Players.Strategies;
using TicTacToe.Games.Players;
using System.IO;


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
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            computerPlayer = new Computer(new HardStrategy());
            computerPlayer.AssignMarker("O");
        }

        [Test]
        public void ComputerPlayerAlwaysWinsOrTiesThreeByThreeBoard()
        {
            string[] emptyThreeByThreeBoard = {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
            List<string[]> initialBoards = Minimax.FindNextBoards(emptyThreeByThreeBoard, "X");
            GameResults(initialBoards);
            Assert.IsTrue(gameResults.All(gameResult => gameResult == "Computer has won or tied"));
        }

        [Test]
        public void ComputerPlayerAlwaysWinsOrTiesFourByFourBoard()
        {
            List<string[]> initialBoards = CreateAndAddInitialBoards();
            GameResults(initialBoards);
            Assert.IsTrue(gameResults.All(gameResult => gameResult == "Computer has won or tied"));
        }

        private void GameResults(List<string[]> boards)
        {
            foreach (string[] board in boards)
            {
                if (gameResults.Count == 20000)
                {
                    break;
                }

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
                    if (ComputerHasWonTheGame(board))
                    {
                        gameResults.Add("Computer has won or tied");
                    }
                    else
                    {
                        int move = computerPlayer.Move(board);
                        board[move] = computerPlayer.marker;
                        List<string[]> nextGroupOfBoards = Minimax.FindNextBoards(board, "X");
                        GameResults(nextGroupOfBoards);
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

        private List<string[]> CreateAndAddInitialBoards()
        {
            List<string[]> initialBoards = new List<string[]>();
            string[] spaceZeroMarkedBoard = {"X", "1", "2", "3",
                                             "4", "5", "6", "7",
                                             "8", "9", "10", "11",
                                             "12", "13", "14", "15"};

            string[] spaceOneMarkedBoard = {"0", "X", "2", "3",
                                            "4", "5", "6", "7",
                                            "8", "9", "10", "11",
                                            "12", "13", "14", "15"};

            string[] spaceTwoMarkedBoard = {"0", "1", "X", "3",
                                            "4", "5", "6", "7",
                                            "8", "9", "10", "11",
                                            "12", "13", "14", "15"};

            string[] spaceFiveMarkedBoard = {"0", "1", "2", "3",
                                              "4", "X", "6", "7",
                                              "8", "9", "10", "11",
                                              "12", "13", "14", "15"};

            initialBoards.Add(spaceZeroMarkedBoard);
            initialBoards.Add(spaceOneMarkedBoard);
            initialBoards.Add(spaceTwoMarkedBoard);
            initialBoards.Add(spaceFiveMarkedBoard);

            return initialBoards;
        }

    }
}
