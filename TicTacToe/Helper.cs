using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Helper
    {
        public static string OppositeMarker(string marker)
        {
            return marker == "X" ? "O" : "X";
        }
    }
}
