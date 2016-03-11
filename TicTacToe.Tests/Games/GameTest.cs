using NUnit.Framework;
using TicTacToe.Games;
using TicTacToe.Games.Players;


namespace TicTacToe.Tests.Games
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
            Player player = new Human();
            game.SetPlayerName(player, name);
            Assert.AreEqual(name, game.PlayerName(player));
        }

        [Test]
        public void GameSetAndReturnPlayerPiece()
        {
            string marker = "X";
            Player player = new Human();
            game.SetPlayerMarker(player, marker);
            Assert.AreEqual(marker , game.PlayerMarker(player));
        }


    }
    
}
