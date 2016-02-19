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
            return "Where would you like to move " + name + "?";
        }

        public static string AskPlayerForPiece()
        {
            return "What piece would you like to be?";
        }

        public static string AskForTurnOrder(string name)
        {
            return "Type 1 if you would like " + name + " to go first, and 2 to go second";
        }
    }
}
