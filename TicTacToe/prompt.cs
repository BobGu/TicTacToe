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
            string marker = Console.ReadLine();
            if (!Validator.Marker(marker))
            {
                Console.WriteLine(marker + " is not a valid input");
                return GetPlayerMarker();
            }
            else
            {
                return marker;
            }
        }

        public static string GetPlayerMove(string name)
        {
            Console.WriteLine(MessageFactory.AskPlayerForMove(name));
            return Console.ReadLine();
        }

        public static string GetTurnOrder(string name)
        {
            Console.WriteLine(MessageFactory.AskForTurnOrder(name));
            string turnOrder = Console.ReadLine();
            if (!Validator.TurnOrder(turnOrder))
            {
                Console.WriteLine(MessageFactory.Invalid(turnOrder));
                return GetTurnOrder(name);
            }
            else
            {
                return turnOrder;
            }
        }

    }
}
