using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IComputerDifficulty
    {
        int BestMove(string[]spaces, string marker);
    }
}
