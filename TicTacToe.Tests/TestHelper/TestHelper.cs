using System;
using System.IO;

namespace TicTacToeTests.TestHelper
{
    public class TestHelper
    {
        public static void SetInput(string input)
        {
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);
        }
    }
}
