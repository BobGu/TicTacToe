using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public string[] players { get; private set;}
        public Board board;

        public void Start()
        {
            players = new string[] { "player1", "player2" };
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
            string[] firstColumn = new string[3];
            for (int i = 0; i < firstColumn.Length; i++)
            {
                firstColumn[i] = board.spaces[i * 3];
            }
            string[][] rows = BoardEvaluator.Rows(spaces);
            return rows.Any(row => BoardEvaluator.AllSpacesTheSame(row)) ||
            BoardEvaluator.AllSpacesTheSame(firstColumn);
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
