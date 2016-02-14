using System;
using TicTacToe;
using NUnit.Framework;
using TicTacToeTests.TestHelper;

namespace GameTest
{
    [TestFixture]
    public class GameTest
    {
        Game game;
        [SetUp]
        public void StartANewGame()
        {
            game = new Game();
            game.Start();
        }

        [Test]
        public void GameIsOverWhenBoardIsFilledAndNotWon()
        {
            string[] spaces = { "X", "O", "X",
                                "X", "X", "O",
                                "O", "X", "O" };
            Assert.IsTrue(game.Over(spaces));
        }

        [Test]
        public void GameIsNotOverWhenBoardIsEmpty()
        {
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsFalse(game.Over(spaces));
        }

        [Test]
        public void GameIsOverWhenGameIsWon()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8"};
            Assert.IsTrue(game.Over(spaces));
        }

        [Test]
        public void GameIsWonWhenOneMarkerHasFilledTopRow()
        {
            string[] spaces = { "X", "X", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsNotWonTopRowIsFilledWithMixedMarkers()
        {
            string[] spaces = { "X", "O", "X",
                                "3", "4", "5",
                                "6", "7", "8" };
            Assert.IsFalse(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenSecondRowIsFilledWithOneMarker()
        {
            string[] spaces = { "0", "1", "2", 
                                "X", "X", "X", 
                                "6", "7", "8" };
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenThirdRowIsFilledWithOneMarker()
        {
            string[] spaces = { "0", "1", "2",
                                "3", "4", "5", 
                                "X", "X", "X" };
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenFirstColumnIsFilledWithOneMarker()
        {
            string[] spaces = { "O", "1", "2",
                                "O", "4", "5",
                                "O", "7", "8"};
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenSecondColumnIsFilledWithOneMarker()
        {
            string[] spaces = {"0", "X", "2",
                               "3", "X", "5",
                               "6", "X", "8"};
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenThirdColumnIsFilledWithOneMarker()
        {
            string[] spaces = {"0", "1", "X",
                               "3", "4", "X",
                               "6", "7", "X"};
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameIsWonWhenFirstDigonalIsFilledWithOneMarker()
        {
            string[] spaces = {"X", "1", "2",
                               "3", "X", "5",
                               "6", "7", "X"};
            Assert.IsTrue(game.Won(spaces)); 
        }

        [Test]
        public void GameIsWonWhenSecondDigonalIsFilledWithOneMarker()
        {
            string[] spaces = {"0", "1", "X",
                               "3", "X", "5",
                               "X", "7", "8"};
            Assert.IsTrue(game.Won(spaces));
        }

        [Test]
        public void GameCanTellBoardToMarkItself()
        {
            Board board = new Board();
            game.MarkBoard(board, 4, "X");
            Assert.AreEqual("X", board.GetSpaceAt(4));
        }

        [Test]
        public void GameSetAndReturnPlayersName()
        {
            string name = "Robert";
            Player player = new Player();
            game.SetPlayerName(player, name);
            Assert.AreEqual(name, game.PlayerName(player));
        }

        [Test]
        public void GameSetAndReturnPlayerPiece()
        {
            string piece = "X";
            Player player = new Player();
            game.SetPlayerPiece(player, piece);
            Assert.AreEqual(piece, game.PlayerPiece(player));
        }

        [Test]
        public void GameStartsWithTwoPlayers()
        {
            Assert.IsInstanceOf<Player>(game.FirstPlayer());
            Assert.IsInstanceOf<Player>(game.SecondPlayer());
        }

        [Test]
        public void GameIsSetupWithPlayersInfo()
        {
            TestHelper.SetInput("Robert\nX\nDon\n1\n");
            game.SetUp();
            Player firstPlayer = game.FirstPlayer;
            Player secondPlayer = game.SecondPlayer;
            string firstPlayerName = game.PlayerName(firstPlayer);
            string secondPlayerName = game.PlayerName(secondPlayer);
            string firstPlayerPiece = game.PlayerPiece(firstPlayer);
            string secondPlayerPiece = game.SecondPlayerPiece(secondPlayer);
            Assert.AreEqual("Robert", firstPlayerName);
            Assert.AreEqual("Don", secondPlayerName);
            Assert.AreEqual("X", firstPlayerPiece);
            Assert.AreEqual("O", secondPlayerPiece);
        }

    }
    
}
