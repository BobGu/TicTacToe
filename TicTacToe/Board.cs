using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        public int[] spaces { get; private set; }

        static void Main(string[] args)
        {
        }

        public Board()
        {
            spaces = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        }
    }
}
