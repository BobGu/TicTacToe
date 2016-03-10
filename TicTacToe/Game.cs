using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {

        private Board board;
        private Player[] players;

        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }

        public Game()
        {
            board = new Board();
        }

        public void Start()
        {
            string gameMode = Prompt.GetInput(MessageHandler.AskPlayerForGameMode, Validator.GameMode);
            ReadGameModeAndInitializePlayers(gameMode);
            SetUp(gameMode);
            Player lastPlayerToMove = Moves();
            WonOrTiedMessage(lastPlayerToMove);
        }

        private void ReadGameModeAndInitializePlayers(string gameMode)
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

        private void SetUp(string gameMode)
        {
            SetPlayerName(FirstPlayer(), Prompt.GetPlayerName());
            string marker = Prompt.GetInput(MessageHandler.AskPlayerForMarker, Validator.Marker);
            SetPlayerMarker(FirstPlayer(), marker);
            SetSecondPlayerName();
            SetPlayerMarker(SecondPlayer(), OppositeMarker.Marker(PlayerMarker(FirstPlayer())));
            AssignTurnOrder(Prompt.GetTurnOrder(PlayerName(FirstPlayer())));
        }
       
        private Player Moves()
        {
            Player currentPlayer = FirstPlayer();
            Turn(currentPlayer);
            while (!Rules.Over(board.spaces))
            {
                currentPlayer = currentPlayer == FirstPlayer() ? SecondPlayer() : FirstPlayer();
                Turn(currentPlayer);
            }
                MessageHandler.PrintBoard(board.spaces);
            return currentPlayer;
        }

        public void WonOrTiedMessage(Player lastPlayerToMove)
        {
            if (Rules.Won(board.spaces))
            {
                MessageHandler.Winner(PlayerName(lastPlayerToMove));
            }
            else
            {
                MessageHandler.Tied();
            }
        }

        private void Turn(Player currentPlayer)
        {
            MessageHandler.PrintBoard(board.spaces);
            int move = currentPlayer.Move(board.spaces);
            MarkBoard(board, move, currentPlayer.marker);
        }

        private void SetSecondPlayerName()
        {
            bool twoPlayerGame =  SecondPlayer() is Human;

            if(twoPlayerGame)
            {
                SetPlayerName(SecondPlayer(), Prompt.GetPlayerName());
            }
            else
            {
                SecondPlayer().AssignName("Johnny 5");
            }
        }

        private void InitializeHumanPlayers()
        {
            players = new Player[] { new Human(), new Human() };
        }

        private void InitializeHumanVsCompuerPlayers()
        {
            string strategyLevel= Prompt.GetInput(MessageHandler.AskPlayerForStrategyLevel, Validator.StrategyLevel);

            if (strategyLevel == GlobalConstants.EasyStrategy) 
            {
                players = new Player[] { new Human(), new Computer(new EasyStrategy()) };
            }
            else
            {
                players = new Player[] { new Human(), new Computer(new HardStrategy()) };
            }
        }

        public void AssignTurnOrder(string turnOrder)
        {
            if (turnOrder == "2")
            {
                players = new Player[] { SecondPlayer(), FirstPlayer() };
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

    }
}
