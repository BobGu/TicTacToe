using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public const string xMarker = "X";
        public const string oMarker = "O";
        public string[] players { get; set;}
        public void Start()
        {
            players = new string[] { "player1", "player2" };
        }

        public bool Won()
        {
            return false;
        }

        public string GetPlayerName()
        {
            MessageFactory.AskPlayerForName();
            return Console.ReadLine();
        }

        public string GetPlayerMove(string name)
        {
            MessageFactory.AskPlayerForMove(name);
            return Console.ReadLine();
        }

        public bool IsNotAnEmptySpace(string space)
        {
            return space == xMarker || space == oMarker;
        }

        public bool Over(string[] spaces)
        {
            return Array.TrueForAll(spaces, IsNotAnEmptySpace);
        }

    }
}
