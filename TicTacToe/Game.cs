using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {

        public Board board;
        public Player[] players { get; private set; }
        public IComputerDifficulty computerDifficulty { get; private set; }

        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }

        public Game()
        {
            board = new Board();
        }

        public void setComputerStrategy(IComputerDifficulty computerDifficulty)
        {
            this.computerDifficulty = computerDifficulty;
        }
       
        public void Moves()
        {
            while (Rules.Over(board.spaces) == false)
            {
                Console.WriteLine(MessageFactory.FormatBoard(board.spaces));
                string move = Prompt.GetPlayerMove(PlayerName(FirstPlayer()), board.spaces);
                Console.WriteLine(move);
                MarkBoard(board, Int32.Parse(move), PlayerMarker(FirstPlayer()));
                players = players.Reverse().ToArray();
            }
        }

        public void SetUp(string gameMode)
        {
            SetPlayerName(FirstPlayer(), Prompt.GetPlayerName());
            string marker = Prompt.GetPlayerMarker();
            SetPlayerMarker(FirstPlayer(), marker);
            if(gameMode == "HH")
            {
                SetPlayerName(SecondPlayer(), Prompt.GetPlayerName());
            }
            else
            {
                SecondPlayer().AssignName();
            }
            SetPlayerMarker(SecondPlayer(), Helper.OppositeMarker(PlayerMarker(FirstPlayer())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(FirstPlayer())));
        }

        public void SetPlayers(string gameMode)
        {
            if (gameMode == "HH")
            {
                players = new Player[] { new Human(), new Human() };
            }
            else
            {
                players = new Player[] { new Human(), new Computer(new HardStrategy()) };
            }
        }

        public void Start()
        {
            string gameMode = Prompt.GetGameMode();
            SetPlayers(gameMode);
            SetUp(gameMode);
            Moves();
            Console.WriteLine(WonOrTiedMessage());
        }

        public string WonOrTiedMessage()
        {
            if (Rules.Won(board.spaces))
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
            return player.name;
        }

        public void SetPlayerMarker(Player player, string marker)
        {
            player.AssignMarker(marker);
        }

        public string PlayerMarker(Player player)
        {
            return player.marker;
        }

        public void MarkBoard(Board board, int space, string marker)
        {
            board.Mark(space, marker);
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
