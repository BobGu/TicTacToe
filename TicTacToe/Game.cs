using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public string[] players { get; set;}
        public void Start()
        {
            players = new string[] { "player1", "player2" };
        }

        public bool Won()
        {
            return false;
        }

        public string AskPlayerForName()
        {
            return "What is your name?";
        }

        public string GetPlayerName()
        {
            AskPlayerForName();
            return Console.ReadLine();
        }

        public string AskPlayerForMove(string name)
        {
            return "Where would you like to move " + name;
        }
    }
}
