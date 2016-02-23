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
            Console.WriteLine(MessageFactory.AskPlayerForName());
            return Console.ReadLine();
        }

        public static string GetPlayerMarker()
        {
            Console.WriteLine(MessageFactory.AskPlayerForPiece());
            return Console.ReadLine();
        }

        public static string GetPlayerMove(string name)
        {
            Console.WriteLine(MessageFactory.AskPlayerForMove(name));
            return Console.ReadLine();
        }

        public static string GetTurnOrder(string name)
        {
            Console.WriteLine(MessageFactory.AskForTurnOrder(name));
            return Console.ReadLine();
        }

    }
}
