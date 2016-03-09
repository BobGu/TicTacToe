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
            MessageHandler.AskPlayerForName();
            return MessageHandler.ReadInput();
        }

        public static int GetPlayerMove(string name, string[] spaces)
        {
            MessageHandler.AskPlayerForMove(name);
            string move = MessageHandler.ReadInput();

            if (!Validator.Move(move, spaces))
            {
                MessageHandler.Invalid(move);
                return GetPlayerMove(name, spaces);
            }
            else
            {
                return ConvertMoveToIndex(move);
            }

        }

        public static string GetTurnOrder(string name)
        {
            MessageHandler.AskForTurnOrder(name);
            string turnOrder = MessageHandler.ReadInput();
            if (!Validator.TurnOrder(turnOrder))
            {
                MessageHandler.Invalid(turnOrder);
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
            string input = MessageHandler.ReadInput();
            if(!validator(input))
            {
                MessageHandler.Invalid(input);
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
