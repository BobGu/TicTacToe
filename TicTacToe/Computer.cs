using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Computer : Player
    {
        private IComputerStrategy strategy;

        public Computer(IComputerStrategy strategy)
        {
            this.strategy = strategy;
        }

        public override int Move(string[] spaces)
        {
            MessagePrinter.AskPlayerForMove(name);
            return strategy.BestMove(spaces, marker);
        }
    }
}
