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

        public static int GetPlayerMove(string name, string[] spaces)
        {
            MessagePrinter.AskPlayerForMove(name);
            string move = Console.ReadLine();

            if (!Validator.Move(move, spaces))
            {
                Console.WriteLine(move + " is not a valid input");
                return GetPlayerMove(name, spaces);
            }
            else
            {
                return ConvertMoveToIndex(move);
            }

        }

        public static string GetTurnOrder(string name)
        {
            MessagePrinter.AskForTurnOrder(name);
            string turnOrder = Console.ReadLine();
            if (!Validator.TurnOrder(turnOrder))
            {
                MessagePrinter.Invalid(turnOrder);
                return GetTurnOrder(name);
            }
            else
            {
                return turnOrder;
            }
        }


        public static string GetInput(Action message, Func<string, bool> validator)
        {
            message();
            string input = Console.ReadLine();
            if(!validator(input))
            {
                MessagePrinter.Invalid(input);
                return GetInput(message, validator);
            }

            else
            {
                return input.ToUpper();
            }
        }

        private static int ConvertMoveToIndex(string move)
        {
            return Int32.Parse(move);
        }

    }
}
