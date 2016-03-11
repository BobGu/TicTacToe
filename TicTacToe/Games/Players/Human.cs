using System;
using TicTacToe.Games.IOValidator;

namespace TicTacToe.Games.Players
{
    public class Human : Player 
    {
        public override int Move(string[] spaces)
        {
            return Prompt.GetPlayerMove(name, spaces);
        }
    }
}
