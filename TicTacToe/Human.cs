﻿using System;

namespace TicTacToe
{
    public class Human : Player 
    {
        public override int Move(string[] spaces)
        {
            return Prompt.GetPlayerMove(name, spaces);
        }
    }
}
