using Othello.Model;

namespace Othello.Abstractions;

public interface IGame
{
    void Start(Player firstPlayer, Player secondPlayer); // Start the game
    void MakeMove(); // Make a move
    bool IsEnded { get; } // Check if the game has ended
    Player CurrentPlayer { get; } // Get the current player
    Player Winner { get; } // Get the winner of the game
    IField GameField { get; } // Get the game field
    
}