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
            MessagePrinter.AskPlayerForName();
            return Console.ReadLine();
        }

        public static string GetPlayerMarker()
        {
            Console.WriteLine(MessagePrinter.AskPlayerForPiece());
            string marker = Console.ReadLine();
            if (!Validator.Marker(marker))
            {
                Console.WriteLine(marker + " is not a valid input");
                return GetPlayerMarker();
            }
            else
            {
                return marker.ToUpper();
            }
        }

        public static int GetPlayerMove(string name, string[] spaces)
        {
            MessagePrinter.AskPlayerForMove(name);
            string move = Console.ReadLine();
            int index;
            if (!Int32.TryParse(move, out index))
            {
                Console.WriteLine(move + " is not a valid input");
                return GetPlayerMove(name, spaces);
            }

            if (!Validator.Move(index, spaces))
            {
                Console.WriteLine(move + " is not a valid input");
                return GetPlayerMove(name, spaces);
            }
            else
            {
                return index;
            }

        }

        public static string GetTurnOrder(string name)
        {
            Console.WriteLine(MessagePrinter.AskForTurnOrder(name));
            string turnOrder = Console.ReadLine();
            if (!Validator.TurnOrder(turnOrder))
            {
                Console.WriteLine(MessagePrinter.Invalid(turnOrder));
                return GetTurnOrder(name);
            }
            else
            {
                return turnOrder;
            }
        }

        public static string GetGameMode()
        {
            Console.WriteLine(MessagePrinter.GameModes());
            string gameMode = Console.ReadLine();

            if (!Validator.GameMode(gameMode))
            {
                Console.WriteLine(MessagePrinter.Invalid(gameMode));
                return GetGameMode();
            }
            else
            {
                return gameMode.ToUpper();
            }
        }

    }
}
