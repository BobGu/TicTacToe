using System;

namespace TicTacToe
{
    public class Human : Player 
    {
        public override int Move(string[] spaces, string name, string marker)
        {
            return Prompt.GetPlayerMove(name, spaces);
        }
    }
}
