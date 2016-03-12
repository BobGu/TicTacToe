using System;
using TicTacToe.Games.RulesAndEvaluator;

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
            string board = "";
            string[][] rows = BoardEvaluator.Rows(spaces);
            int lengthOfRow = BoardEvaluator.WidthOfBoard(spaces);

            for(int currentRowIndex = 0; currentRowIndex < rows.Length; currentRowIndex += 1)
            {
                string row = "";
                for (int currentSpaceIndex = 0; currentSpaceIndex < rows.Length; currentSpaceIndex += 1)
                {
                    int index = currentRowIndex * lengthOfRow + currentSpaceIndex;
                    row =  string.Format(@"{0} {1} | ", row, spaces[index]);
                }

                board = string.Format(@"{0}

                                        {1}", board, row);
            }

            Console.WriteLine(board);
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
