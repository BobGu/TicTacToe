﻿using System;
using TicTacToe;
using NUnit.Framework;
using TicTacToe.Tests.TestHelper;


namespace TicTacToe.Tests
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
            string piece = "X";
            Player player = new Human();
            game.SetPlayerMarker(player, piece);
            Assert.AreEqual(piece, game.PlayerMarker(player));
        }

        [Test]
        public void GameCanAssignTurnOrder()
        {
            game.InitializeHumanPlayers();
            Player firstPlayerToEnterInfo = game.FirstPlayer();
            game.AssignTurnOrder("2");
            Assert.AreNotEqual(firstPlayerToEnterInfo, game.FirstPlayer());
        }

        [Test]
        public void GamesPlayersAreHumanIfHumanvsHumanGame()
        {
            game.ReadGameModeAndInitializePlayers("HH");
            Assert.IsInstanceOf(typeof(Human), game.FirstPlayer());
            Assert.IsInstanceOf(typeof(Human), game.SecondPlayer());
        }

        [Test]
        public void GamesSecondPlayerIsComputerIfComputerVsComputerGameMode()
        {
            TestHelper.TestHelper.SetInput("E");
            game.ReadGameModeAndInitializePlayers("HC");
            Assert.IsInstanceOf(typeof(Computer), game.SecondPlayer());
        }

        

    }
    
}
