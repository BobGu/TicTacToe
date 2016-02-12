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
            return BoardEvaluator.AnySetsTheSame(spaces);
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
