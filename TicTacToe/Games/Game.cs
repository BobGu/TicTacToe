﻿using System;
using System.Linq;
using TicTacToe.Games.Players;
using TicTacToe.Games.Players.Strategies;
using TicTacToe.Games.RulesAndEvaluator;
using TicTacToe.Games.IOValidator;
using TicTacToe.GlobalConstants;
using TicTacToe.Games.Setups;

namespace TicTacToe.Games
{
    public class Game
    {
        private Board board;
        private PlayerSetup setup;
        private Player[] players;

        public Game()
        {
            board = new Board();
        }

        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }

        public void Start()
        {
            string gameMode = Prompt.GetInput(MessageHandler.AskPlayerForGameMode, Validator.GameMode);
            ReadGameModeAndInitializePlayers(gameMode);
            PlayerSetup(gameMode);
            Player lastPlayerToMove = Moves();
            WonOrTiedMessage(lastPlayerToMove);
        }

        private void PlayerSetup(string gameMode)
        {
            setup = new PlayerSetup(players);
            setup.Setup(gameMode);
            players = setup.players;
        }

        private void ReadGameModeAndInitializePlayers(string gameMode)
        {
            if (GlobalConstant.HumanVsHuman  == gameMode)
            {
                InitializeHumanPlayers();
            }
            else
            {
                InitializeHumanVsCompuerPlayers();
            }
        }

        private Player Moves()
        {
            Player currentPlayer = FirstPlayer();
            Turn(currentPlayer);
            while (!Rules.Over(board.spaces))
            {
                currentPlayer = currentPlayer == FirstPlayer() ? SecondPlayer() : FirstPlayer();
                Turn(currentPlayer);
            }
                MessageHandler.PrintBoard(board.spaces);
            return currentPlayer;
        }

        private void WonOrTiedMessage(Player lastPlayerToMove)
        {
            if (Rules.Won(board.spaces))
            {
                MessageHandler.Winner(lastPlayerToMove.name);
            }
            else
            {
                MessageHandler.Tied();
            }
        }

        private void Turn(Player currentPlayer)
        {
            MessageHandler.PrintBoard(board.spaces);
            int move = currentPlayer.Move(board.spaces);
            MarkBoard(board, move, currentPlayer.marker);
        }


        private void InitializeHumanPlayers()
        {
            players = new Player[] { new Human(), new Human() };
        }

        private void InitializeHumanVsCompuerPlayers()
        {
            string strategyLevel= Prompt.GetInput(MessageHandler.AskPlayerForStrategyLevel, Validator.StrategyLevel);

            if (strategyLevel == GlobalConstant.EasyStrategy) 
            {
                players = new Player[] { new Human(), new Computer(new EasyStrategy()) };
            }
            else
            {
                players = new Player[] { new Human(), new Computer(new HardStrategy()) };
            }
        }

        private Player FirstPlayer()
        {
            return players.First();
        }

        private Player SecondPlayer()
        {
            return players.Last();
        }

        private void MarkBoard(Board board, int space, string marker)
        {
            board.Mark(space, marker);
        }

    }
}
