using System;

namespace TicTacToe
{
    public class MessageFactory
    {
        public static string AskPlayerForName()
        {
            return "What is your name?";
        }

        public static string AskPlayerForMove(string name)
        {
            return "Where would you like to move " + name;
        }

        public static string AskPlayerForPiece()
        {
            return "What piece would you like to be?";
        }
    }
}
