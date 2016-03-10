using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Games.IOValidator;
using TicTacToe.Games.Players.Strategies;

namespace TicTacToe.Games.Players
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
            MessageHandler.AskPlayerForMove(name);
            return strategy.BestMove(spaces, marker);
        }
    }
}
