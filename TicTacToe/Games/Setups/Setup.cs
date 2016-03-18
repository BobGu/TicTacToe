using System.Collections.Generic;
using System;
using TicTacToe.Games.Players;
using TicTacToe.Games.IOValidator;
using TicTacToe.Games.OppositeMarkers;
using System.Linq;

namespace TicTacToe.Games.Setups
{
    public class Setup
    {
        public Player[] players { get; private set; }
        private int boardDimmensions;

        public Setup(Player[] players)
        {
            this.players = players;
        }

        public int GetBoardDimmensions()
        {
            return boardDimmensions;
        }

        public void SetBoardDimmensions(string boardDimmensions)
        {
            this.boardDimmensions = Int32.Parse(boardDimmensions);
        }

        public void Start(string gameMode)
        {
            SetPlayerName(players.First(), Prompt.GetPlayerName());
            string marker = Prompt.GetInput(MessageHandler.AskPlayerForMarker, Validator.Marker);
            SetPlayerMarker(players.First(), marker);
            SetSecondPlayerName();
            SetPlayerMarker(players.Last(), OppositeMarker.Marker(PlayerMarker(players.First())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(players.First())));
            string boardDimmensions = Prompt.GetInput(MessageHandler.AskPlayerForBoardDimmensions, Validator.BoardDimmensions);
            SetBoardDimmensions(boardDimmensions);
        }

        private void SetSecondPlayerName()
        {
            bool twoPlayerGame =  players.Last() is Human;

            if(twoPlayerGame)
            {
                SetPlayerName(players.Last(), Prompt.GetPlayerName());
            }
            else
            {
                players.Last().AssignName("Johnny 5");
            }
        }

        private void SetPlayerName(Player player, string name)
        {
            player.AssignName(name);
        }

        private void SetPlayerMarker(Player player, string marker)
        {
            player.AssignMarker(marker);
        }

        private void AssignTurnOrder(string turnOrder)
        {
            if (turnOrder == "2")
            {
                players = new Player[] { players.Last(), players.First() };
            }
        }

        private string PlayerMarker(Player player)
        {
            return player.GetMarker();
        }

        private string PlayerName(Player player)
        {
            return player.GetName();
        }

    }
}
