using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Computer : Player
    {
        public IComputerDifficulty strategy{ get; private set; }

        public Computer(IComputerDifficulty strategy)
        {
            this.strategy = strategy;
        }

        public int Move(string[] spaces, string marker)
        {
            return strategy.BestMove(spaces, marker);
        }
    }
}
