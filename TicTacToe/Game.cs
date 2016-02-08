using System;
using My.Extensions;
using System.Linq;

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

        public bool AllSpacesTheSame(string[] spaces)
        {
            return 1 == spaces.Distinct().ToArray().Length;
        }

        public bool Over(string[] spaces)
        {
            return Array.TrueForAll(spaces, IsNotAnEmptySpace);
        }

        public bool Won(string[] spaces)
        {
            string[] firstRow = spaces.SubArray(0, 3);
            string[] secondRow = spaces.SubArray(3, 3);
            return AllSpacesTheSame(firstRow) || AllSpacesTheSame(secondRow);
        }

    }
}
