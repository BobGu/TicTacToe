using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Prompt
    {
        public static string GetPlayerName()
        {
            MessageFactory.AskPlayerForName();
            return Console.ReadLine();
        }

        public static string GetPlayerPiece()
        {
            MessageFactory.AskPlayerForPiece();
            return Console.ReadLine();
        }

        public static string GetPlayerMove(string name)
        {
            MessageFactory.AskPlayerForMove(name);
            return Console.ReadLine();
        }

    }
}
