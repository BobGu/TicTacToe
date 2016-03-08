﻿using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {

        public Board board;
        public Player[] players { get; private set; }
        public IComputerStrategy computerStrategy{ get; private set; }

        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }

        public Game()
        {
            board = new Board();
        }

        public void setComputerStrategy(IComputerStrategy computerStrategy)
        {
            this.computerStrategy= computerStrategy;
        }
       
        public void Moves()
        {
            while (!Rules.Over(board.spaces))
            {
                MessagePrinter.PrintBoard(board.spaces);
                Player currentPlayer = FirstPlayer();
                int move = currentPlayer.Move(board.spaces, currentPlayer.name, currentPlayer.marker);
                MarkBoard(board, move, currentPlayer.marker);
                players = players.Reverse().ToArray();
            }
                MessagePrinter.PrintBoard(board.spaces);
        }

        public void SetUp(string gameMode)
        {
            SetPlayerName(FirstPlayer(), Prompt.GetPlayerName());
            string marker = Prompt.GetPlayerMarker();
            SetPlayerMarker(FirstPlayer(), marker);
            if(GlobalConstants.HumanVsHuman == gameMode)
            {
                SetPlayerName(SecondPlayer(), Prompt.GetPlayerName());
            }
            else
            {
                SecondPlayer().AssignName();
            }
            SetPlayerMarker(SecondPlayer(), Helper.OppositeMarker(PlayerMarker(FirstPlayer())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(FirstPlayer())));
        }

        public void SetHumanPlayers()
        {
            players = new Player[] { new Human(), new Human() };
        }

        public void SetHumanVsComputerPlayers()
        {
            string strategyLevel= Prompt.GetStrategyLevel();

            if (strategyLevel == GlobalConstants.EasyStrategy) 
            {
                players = new Player[] { new Human(), new Computer(new EasyStrategy()) };
            }
            else
            {
                players = new Player[] { new Human(), new Computer(new HardStrategy()) };
            }
        }

        public void ReadGameModeAndSetPlayers(string gameMode)
        {
            if (GlobalConstants.HumanVsHuman  == gameMode)
            {
                SetHumanPlayers();
            }
            else
            {
                SetHumanVsComputerPlayers();
            }
        }

        public void Start()
        {
            string gameMode = Prompt.GetGameMode();
            ReadGameModeAndSetPlayers(gameMode);
            SetUp(gameMode);
            Moves();
            WonOrTiedMessage();
        }

        public void WonOrTiedMessage()
        {
            if (Rules.Won(board.spaces))
            {
                MessagePrinter.Winner(PlayerName(SecondPlayer()));
            }
            else
            {
                MessagePrinter.Tied();
            }
        }


        public Player FirstPlayer()
        {
            return players.First();
        }

        public Player SecondPlayer()
        {
            return players.Last();
        }

        public void SetPlayerName(Player player, string name)
        {
            player.AssignName(name);
        }

        public string PlayerName(Player player)
        {
            return player.name;
        }

        public void SetPlayerMarker(Player player, string marker)
        {
            player.AssignMarker(marker);
        }

        public string PlayerMarker(Player player)
        {
            return player.marker;
        }

        public void MarkBoard(Board board, int space, string marker)
        {
            board.Mark(space, marker);
        }

        public void AssignTurnOrder(string turnOrder)
        {
            if (turnOrder == "2")
            {
                players = new Player[] { SecondPlayer(), FirstPlayer() };
            }
        }


    }
}
