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
            game.SetPlayerMarker(player, piece);
            Assert.AreEqual(piece, game.PlayerMarker(player));
        }

        [Test]
        public void GameCanAssignTurnOrder()
        {
            game.SetPlayerName(game.FirstPlayer(), "Bob");
            game.SetPlayerName(game.SecondPlayer(), "John");
            game.AssignTurnOrder("1");
            Assert.AreEqual("Bob", game.PlayerName(game.FirstPlayer()));
            game.AssignTurnOrder("2");
            Assert.AreEqual("John", game.PlayerName(game.FirstPlayer()));
        }


    }
    
}
