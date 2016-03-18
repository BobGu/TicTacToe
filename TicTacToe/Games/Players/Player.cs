using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Games.Players
{
    public abstract class Player
    {
        private string name;
        private string marker;

        public string GetName()
        {
            return name;
        }

        public string GetMarker()
        {
            return marker;
        }

        public void AssignName(string name)
        {
            this.name = name;
        }
        public void AssignMarker(string marker)
        {
            this.marker = marker;
        }

        public abstract int Move(string[] spaces);
    }

}
