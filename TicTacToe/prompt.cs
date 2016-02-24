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

        public static string GetPlayerMove(string name, string[] spaces)
        {
            Console.WriteLine(MessageFactory.AskPlayerForMove(name));
            string move = Console.ReadLine();
            int index;
            if (Int32.TryParse(move, out index))
            {
                if (!Validator.Move(index, spaces))
                {
                    return GetPlayerMove(name, spaces);
                }
                else
                {
                    return move;
                }
            }

            else
            {
                return GetPlayerMove(name, spaces);
            }

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
