using System;
using My.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public string[] players { get; private set;}

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

        public bool Over(string[] spaces)
        {
            return Array.TrueForAll(spaces, BoardEvaluator.IsNotAnEmptySpace);
        }

        public bool Won(string[] spaces)
        {
            int lengthOfRow = Convert.ToInt32(Math.Sqrt(spaces.Length));
            for (int i = 0; i < 9; i += 3)
            {
                string[] row = spaces.SubArray(i, lengthOfRow);
                if (BoardEvaluator.AllSpacesTheSame(row))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
