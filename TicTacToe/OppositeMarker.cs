using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class OppositeMarker
    {
        public static string Marker(string marker)
        {
            return marker == GlobalConstants.XMarker ? GlobalConstants.OMarker : GlobalConstants.XMarker;
        }
    }
}
