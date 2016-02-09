using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.Extensions;

namespace TicTacToe
{
    public class Board
    {

        static void Main(string[] args)
        {
        }

        public string[] spaces { get; private set; }

        public Board()
        {
            spaces = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        }
        

        public string[][] Rows()
        {
            string[][] rows = new string[3][];
            int lengthOfRow = Convert.ToInt32(Math.Sqrt(spaces.Length));
            for (int i = 0; i < 3; i += 1)
            {
                string[] row = spaces.SubArray(i * lengthOfRow, lengthOfRow);
                rows[i] = row;
            }
            return rows;
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
