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
                return marker.ToUpper();
            }
        }

        public static int GetPlayerMove(string name, string[] spaces)
        {
            MessageFactory.AskPlayerForMove(name);
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

        public static string GetGameMode()
        {
            Console.WriteLine(MessageFactory.GameModes());
            string gameMode = Console.ReadLine();

            if (!Validator.GameMode(gameMode))
            {
                Console.WriteLine(MessageFactory.Invalid(gameMode));
                return GetGameMode();
            }
            else
            {
                return gameMode.ToUpper();
            }
        }

    }
}
