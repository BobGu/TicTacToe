using System;

namespace TicTacToe.Games.Players.Strategies
{
    public interface IComputerStrategy
    {
        int BestMove(string[]spaces, string marker);
    }
}
