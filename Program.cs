using Othello.Abstractions;
using Othello.Controller;
using Othello.Model;
using Othello.View;

namespace Othello
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up dependencies
            IField gameField = new Field();
            var game = new Events(gameField );
            Start gameController = new Start(game);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            
            // Listen to game events
            consoleOutput.ListenTo(game);

            // Start the game
            gameController.StartGame();
        }
    }
}