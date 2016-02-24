using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {

        public Board board;
        public Player[] players { get; private set; }

        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }

        public Game()
        {
            players = new Player[] { new Player(), new Player() };
            board = new Board();
        }
       

        public void Moves()
        {
            while (Over(board.spaces) == false)
            {
                Console.WriteLine(MessageFactory.FormatBoard(board.spaces));
                string move = Prompt.GetPlayerMove(PlayerName(FirstPlayer()), board.spaces);
                Console.WriteLine(move);
                MarkBoard(board, Int32.Parse(move), PlayerMarker(FirstPlayer()));
                players = players.Reverse().ToArray();
            }
        }

        public void SetUp()
        {
            SetPlayerName(FirstPlayer(), Prompt.GetPlayerName());
            string marker = Prompt.GetPlayerMarker();
            SetPlayerMarker(FirstPlayer(), marker);
            SetPlayerName(SecondPlayer(), Prompt.GetPlayerName());
            SetPlayerMarker(SecondPlayer(), OppositeMarker(PlayerMarker(FirstPlayer())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(FirstPlayer())));
        }

        public void Start()
        {
            SetUp();
            Moves();
            Console.WriteLine(WonOrTiedMessage());
        }

        public string WonOrTiedMessage()
        {
            if (Won(board.spaces))
            {
                return MessageFactory.Winner(PlayerName(SecondPlayer()));
            }
            else
            {
                return MessageFactory.Tied();
            }
        }


        public Player FirstPlayer()
        {
            return players.First();
        }

        public Player SecondPlayer()
        {
            return players.Last();
        }

        public void SetPlayerName(Player player, string name)
        {
            player.AssignName(name);
        }

        public string PlayerName(Player player)
        {
            return player.Name();
        }

        public void SetPlayerMarker(Player player, string marker)
        {
            player.AssignMarker(marker);
        }

        public string PlayerMarker(Player player)
        {
            return player.Marker();
        }

        public bool Won(string[] spaces)
        {
            return BoardEvaluator.AnySetsTheSame(spaces);
        }

        public bool Over(string[] spaces)
        {
            return Won(spaces) || BoardEvaluator.AllSpacesNotEmpty(spaces);
        }

        public void MarkBoard(Board board, int space, string marker)
        {
            board.Mark(space, marker);
        }

        public string OppositeMarker(string marker)
        {
            return marker == "X" ? "O" : "X";
        }

        public void AssignTurnOrder(string turnOrder)
        {
            if (turnOrder == "2")
            {
                players = new Player[] { SecondPlayer(), FirstPlayer() };
            }
        }


    }
}
