using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public Board board;

        public void Start()
        {
            board = new Board();
        }

        public string GetPlayerName()
        {
            MessageFactory.AskPlayerForName();
            return Console.ReadLine();
        }

        public string GetPlayerMove(string name)
        {
            MessageFactory.AskPlayerForMove(name);
            return Console.ReadLine();
        }

        public bool Won(string[] spaces)
        {
            string[][] columns = BoardEvaluator.Columns(spaces);
            string[][] rows = BoardEvaluator.Rows(spaces);
            string[][] diagonals = BoardEvaluator.Diagonals(spaces);
            return rows.Any(row => BoardEvaluator.AllSpacesTheSame(row)) ||
                   columns.Any(column => BoardEvaluator.AllSpacesTheSame(column)) ||
                   diagonals.Any(diagonal => BoardEvaluator.AllSpacesTheSame(diagonal));
        }

        public bool Over(string[] spaces)
        {
            return Won(spaces) || BoardEvaluator.AllSpacesNotEmpty(spaces);
        }

        public void MarkBoard(Board board, int space, string marker)
        {
            board.Mark(space, marker);
        }

    }
}
