using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public string name { get; private set; }

        public void AssignName(string name)
        {
            this.name = name;
        }
        public string Name()
        {
            return name;
        }
    }
}
