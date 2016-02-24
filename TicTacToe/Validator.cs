using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Validator
    {
        public static bool Marker(string marker)
        {
            marker = marker.ToUpper();
            return marker == "X" || marker == "O";
        }

        public static bool TurnOrder(string turnOrder)
        {
            return turnOrder == "1" || turnOrder == "2";
        }

        public static bool Move(int move, string[] spaces)
        {
            bool inBoundsMove = move < spaces.Length && move >=  0;
            return inBoundsMove && spaces[move] != "X" && spaces[move] != "O";
        }

        public static bool CanConvertStringToInteger(string move)
        {
            int index;
            return Int32.TryParse(move, out index);
        }
    }
}
