using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public Board board;
        public Player[] players { get; private set; }

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

        public void SetPlayerPiece(Player player, string piece)
        {
            player.AssignPiece(piece);
        }

        public string PlayerPiece(Player player)
        {
            return player.Piece();
        }

        public string OppositePiece(string piece)
        {
            return piece == "X" ? "O" : "X";
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

        public void SetUp()
        {
            string firstPlayerName = Prompt.GetPlayerName();
            Prompt.GetPlayerPiece();
            Prompt.GetPlayerName();
            Prompt.GetTurnOrder(firstPlayerName);
        }

        public void Start()
        {
            board = new Board();
            SetUp();
        }

    }
}
