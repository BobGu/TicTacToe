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

        public string GetPlayerName()
        {
            MessageFactory.AskPlayerForName();
            return Console.ReadLine();
        }

    }
}
