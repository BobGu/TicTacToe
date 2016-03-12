using System.Collections.Generic;
using TicTacToe.Games.Players;
using TicTacToe.Games.IOValidator;
using TicTacToe.Games.OppositeMarkers;
using System.Linq;

namespace TicTacToe.Games.Setups
{
    public class PlayerSetup
    {
        public Player[] players { get; private set; }
        private Board board;

        public PlayerSetup(Player[] players)
        {
            this.players = players;
        }

        public void Setup(string gameMode)
        {
            SetPlayerName(players.First(), Prompt.GetPlayerName());
            string marker = Prompt.GetInput(MessageHandler.AskPlayerForMarker, Validator.Marker);
            SetPlayerMarker(players.First(), marker);
            SetSecondPlayerName();
            SetPlayerMarker(players.Last(), OppositeMarker.Marker(PlayerMarker(players.First())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(players.First())));
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
            return player.marker;
        }

        private string PlayerName(Player player)
        {
            return player.name;
        }

    }
}
