using System;

namespace TicTacToe
{
    public class Human : Player 
    {
        public int Move(string name, string[] spaces)
        {
            return Prompt.GetPlayerMove(name, spaces);
        }
    }
}
