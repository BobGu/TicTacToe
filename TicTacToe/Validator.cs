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
    }
}
