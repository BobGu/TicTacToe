using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Rules
    {
        public static bool Won(string[] spaces)
        {
            return BoardEvaluator.AnySetsTheSame(spaces);
        }

        public static bool Over(string[] spaces)
        {
            return Won(spaces) || BoardEvaluator.AllSpacesNotEmpty(spaces);
        }
       
    }
}
