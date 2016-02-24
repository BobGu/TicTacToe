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
            return "What piece would you like to be, X or O?";
        }

        public static string AskForTurnOrder(string name)
        {
            return "Type 1 if you would like " + name + " to go first, and 2 to go second";
        }

        public static string FormatBoard(string[] spaces)
        {
            return string.Format(
                @"               

                   {0}   |  {1}  |  {2}  |
                  _____|_____|_____|
                       |     |     |
                   {3}   |  {4}  |  {5}  |
                  _____|_____|_____|
                       |     |     |
                   {6}   |  {7}  |  {8}  |
                  _____|_____|_____|"
                , spaces[0], spaces[1], spaces[2],
                spaces[3], spaces[4], spaces[5],
                spaces[6], spaces[7], spaces[8]);
        }

        public static string Winner(string name)
        {
            return name + " has won the game";
        }

        public static string Tied()
        {
            return "The game is a tie";
        }

        public static string Invalid(string input)
        {
            return input + " is not a valid input";
        }
    }
}
