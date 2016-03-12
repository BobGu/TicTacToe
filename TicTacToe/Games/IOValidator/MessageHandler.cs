using System;

namespace TicTacToe.Games.IOValidator
{
    public class MessageHandler
    {
        public static void AskPlayerForName()
        {
            Console.WriteLine("What is your name?");
        }

        public static void AskPlayerForMove(string name)
        {
            Console.WriteLine("Where would you like to move " + name + "?");
        }

        public static void AskPlayerForMarker()
        {
            Console.WriteLine("What piece would you like to be, X or O?");
        }

        public static void AskForTurnOrder(string name)
        {
            Console.WriteLine("Type 1 if you would like " + name + " to go first, and 2 to go second");
        }

        public static void PrintBoard(string[] spaces)
        {
            Console.WriteLine(string.Format(
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
                spaces[6], spaces[7], spaces[8]));
        }

        public static void Winner(string name)
        {
            Console.WriteLine(name + " has won the game");
        }

        public static void Tied()
        {
            Console.WriteLine("The game is a tie");
        }

        public static void Invalid(string input)
        {
            Console.WriteLine(input + " is not a valid input");
        }

        public static void AskPlayerForGameMode()
        {
            Console.WriteLine("Type in hh to play human vs human, and hc for human vs computer");
        }

        public static void AskPlayerForStrategyLevel()
        {
            Console.WriteLine("Type in E for easy or H for hard difficulty");
        }

        public static string ReadInput()
        {
            return Console.ReadLine();
        }

        public static void AskPlayerForBoardDimmensions()
        {
            Console.WriteLine("Type in 3 to play on a 3 by 3 board, or 4 for a 4 by 4 board");
        }
    }
}
