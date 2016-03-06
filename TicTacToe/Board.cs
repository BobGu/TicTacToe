using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {

        public string[] spaces { get; }

        public Board()
        {
            spaces = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        }
        
        public void Mark(int space, string piece)
        {
            spaces[space] = piece;
        }

        public string GetSpaceAt(int space)
        {
            return spaces[space];
        }
    }
}
