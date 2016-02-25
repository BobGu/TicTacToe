using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HardStrategy
    {
        public static int Score(string[] spaces)
        {
            return Rules.Won(spaces) ? 10 : 0;
        }

        public static string OppositeMarker(string marker)
        {
            return marker == "X" ? "O" : "X";
        }

        public static int Minimax(string[] spaces, string marker, bool maximizingPlayer)
        {
            if (Rules.Over(spaces))
            {
                if (maximizingPlayer)
                {
                    return Score(spaces);
                }
                else
                {
                    return Score(spaces) * -1;
                }
            }

            maximizingPlayer = !maximizingPlayer;
            string oppositeMarker = OppositeMarker(marker);
            string[] availableSpaces = BoardEvaluator.AvailableSpaces(spaces);

            if (maximizingPlayer)
            {
                int bestValue = -1000;
                foreach (string space in availableSpaces)
                {
                    int index = Int32.Parse(space);
                    spaces[index] = oppositeMarker;
                    int value = Minimax(spaces, oppositeMarker, maximizingPlayer);
                    List<int> values = new List<int>();
                    values.Add(bestValue);
                    values.Add(value);
                    return values.Max();
                }
            }

            else
            {
                int bestValue = 1000;
                foreach (string space in availableSpaces)
                {
                    int index = Int32.Parse(space);
                    spaces[index] = oppositeMarker;
                    int value = Minimax(spaces, oppositeMarker, maximizingPlayer);
                    List<int> values = new List<int>();
                    values.Add(bestValue);
                    values.Add(value);
                    return values.Min();
                }
            }

            return Minimax(spaces, oppositeMarker, maximizingPlayer);
            
        }

        public static int BestMove(string[] spaces, string marker)
        {
            return 2;
        }
    }
}
