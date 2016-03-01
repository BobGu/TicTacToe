using System;

namespace TicTacToe
{
    public class Human : IPlayer 
    {
        public string name { get; private set; }
        public string piece { get; private set; }
        
        public void AssignName(string name)
        {
            this.name = name;
        }

        public void AssignPiece(string piece)
        {
            this.piece = piece;
        }
    }
}
