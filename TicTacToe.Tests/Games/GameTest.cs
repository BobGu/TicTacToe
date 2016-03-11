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

    }
    
}
