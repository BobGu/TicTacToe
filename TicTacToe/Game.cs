using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {

        public Board board;
        public Player[] players { get; private set; }
        public IComputerStrategy computerStrategy{ get; private set; }

        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }

        public Game()
        {
            board = new Board();
        }

        public void setComputerStrategy(IComputerStrategy computerStrategy)
        {
            this.computerStrategy= computerStrategy;
        }

        public void Turn(Player currentPlayer)
        {
            MessagePrinter.PrintBoard(board.spaces);
            int move = currentPlayer.Move(board.spaces);
            MarkBoard(board, move, currentPlayer.marker);
        }
       
        public Player Moves()
        {
            Player currentPlayer = FirstPlayer();
            Turn(currentPlayer);
            while (!Rules.Over(board.spaces))
            {
                currentPlayer = currentPlayer == FirstPlayer() ? SecondPlayer() : FirstPlayer();
                Turn(currentPlayer);
            }
                MessagePrinter.PrintBoard(board.spaces);
            return currentPlayer;
        }

        public void SetSecondPlayerName()
        {
            bool twoPlayerGame =  SecondPlayer() is Human;

            if(twoPlayerGame)
            {
                SetPlayerName(SecondPlayer(), Prompt.GetPlayerName());
            }
            else
            {
                SecondPlayer().AssignName();
            }
        }
        public void SetUp(string gameMode)
        {
            SetPlayerName(FirstPlayer(), Prompt.GetPlayerName());
            string marker = Prompt.GetPlayerMarker();
            SetPlayerMarker(FirstPlayer(), marker);
            SetSecondPlayerName();
            SetPlayerMarker(SecondPlayer(), Helper.OppositeMarker(PlayerMarker(FirstPlayer())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(FirstPlayer())));
        }

        public void InitializeHumanPlayers()
        {
            players = new Player[] { new Human(), new Human() };
        }

        public void InitializeHumanVsCompuerPlayers()
        {
            string strategyLevel= Prompt.GetStrategyLevel();

            if (strategyLevel == GlobalConstants.EasyStrategy) 
            {
                players = new Player[] { new Human(), new Computer(new EasyStrategy()) };
            }
            else
            {
                players = new Player[] { new Human(), new Computer(new HardStrategy()) };
            }
        }

        public void ReadGameModeAndInitializePlayers(string gameMode)
        {
            if (GlobalConstants.HumanVsHuman  == gameMode)
            {
                InitializeHumanPlayers();
            }
            else
            {
                InitializeHumanVsCompuerPlayers();
            }
        }

        public void Start()
        {
            string gameMode = Prompt.GetGameMode();
            ReadGameModeAndInitializePlayers(gameMode);
            SetUp(gameMode);
            Player lastPlayerToMove = Moves();
            WonOrTiedMessage(lastPlayerToMove);
        }

        public void WonOrTiedMessage(Player lastPlayerToMove)
        {
            if (Rules.Won(board.spaces))
            {
                MessagePrinter.Winner(PlayerName(lastPlayerToMove));
            }
            else
            {
                MessagePrinter.Tied();
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
