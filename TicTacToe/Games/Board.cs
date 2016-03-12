﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Games
{
    public class Board
    {
        public string[] spaces { get; }

        public Board(int boardDimmensions)
        {
            spaces = CreateSpaces(boardDimmensions);
        }
        
        public void Mark(int space, string piece)
        {
            spaces[space] = piece;
        }

        public string GetSpaceAt(int space)
        {
            return spaces[space];
        }

        private string[] CreateSpaces(int boardDimmensions)
        {
            int numberOfSpaces = boardDimmensions * boardDimmensions;
            int[] intSpaces = Enumerable.Range(0, numberOfSpaces).ToArray();
            return intSpaces.Select(number => number.ToString()).ToArray();
        }

    }
}
