using Othello.Abstractions;
using Othello.Model;
using System;
using System.Threading;

namespace Othello.Controller
{
    public class Start
    {
        private IGame game;

        public Start(IGame game)
        {
            this.game = game;
        }

        public void StartGame()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter 'start PvP' for Player vs. Player mode or 'start PvE' for Player vs. Bot mode:");
                string command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "start pvp":
                        PlayGame(new PvPLogic("X" , new CordinatesTaker()), new PvPLogic("O", new CordinatesTaker()));
                        break;
                    case "start pve":
                        PlayGame(new PvPLogic("X" , new CordinatesTaker()), new PvELogic("B"));
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please enter 'start PvP', 'start PvE', or 'exit'.");
                        break;
                }
            }
        }

        private void PlayGame(Player firstPlayer, Player secondPlayer)
        {
            // Start the game
            game.Start(firstPlayer,secondPlayer);

            // Main game loop
            while (!game.IsEnded)
            {
                Console.WriteLine($"Player {game.CurrentPlayer.Name}'s turn. Enter your move (X Y):");
                game.MakeMove();
            }

            // Game ended, display result
            if (game.Winner != null)
            {
                Console.WriteLine($"Player {game.Winner.Name} wins!");
            }
            else
            {
                Console.WriteLine("The game ended in a draw.");
            }
        }
    }
}
