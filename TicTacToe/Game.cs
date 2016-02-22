using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public Board board;
        public Player[] players { get; private set; }

        public void Main()
        {
            Start();
        }

        public Game()
        {
            players = new Player[] { new Player(), new Player() };
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
            return player.Name();
        }

        public void SetPlayerMarker(Player player, string marker)
        {
            player.AssignMarker(marker);
        }

        public string PlayerMarker(Player player)
        {
            return player.Marker();
        }

        public bool Won(string[] spaces)
        {
            return BoardEvaluator.AnySetsTheSame(spaces);
        }

        public bool Over(string[] spaces)
        {
            return Won(spaces) || BoardEvaluator.AllSpacesNotEmpty(spaces);
        }

        public void MarkBoard(Board board, int space, string marker)
        {
            board.Mark(space, marker);
        }

        public string OppositeMarker(string marker)
        {
            return marker == "X" ? "O" : "X";
        }

        public void AssignTurnOrder(string turnOrder)
        {
            if (turnOrder == "2")
            {
                players = new Player[] { SecondPlayer(), FirstPlayer() };
            }
        }

        public void Moves()
        {
            Prompt.GetPlayerMove(PlayerName(FirstPlayer()));
            Console.WriteLine(MessageFactory.FormatBoard(board.spaces));
        }

        public void SetUp()
        {
            SetPlayerName(FirstPlayer(), Prompt.GetPlayerName());
            SetPlayerMarker(FirstPlayer(), Prompt.GetPlayerMarker());
            SetPlayerName(SecondPlayer(), Prompt.GetPlayerName());
            SetPlayerMarker(SecondPlayer(), OppositeMarker(PlayerMarker(FirstPlayer())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(FirstPlayer())));
            Moves();
        }

        public void Start()
        {
            board = new Board();
            SetUp();
        }

    }
}
