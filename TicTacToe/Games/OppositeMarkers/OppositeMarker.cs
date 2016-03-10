using TicTacToe.GlobalConstants;

namespace TicTacToe.Games.OppositeMarkers
{
    public class OppositeMarker
    {
        public static string Marker(string marker)
        {
            return marker == GlobalConstant.XMarker ? GlobalConstant.OMarker : GlobalConstant.XMarker;
        }
    }
}
