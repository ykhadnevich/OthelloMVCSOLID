using Othello.Model;

namespace Othello.Abstractions;

public interface  IField
{
    int Size { get; } // Size of the game field (assuming square)
    Cell[,] GetField(); // Get the current state of the field
    void InitializeField(Player CurrentPlayer,Player firstPlayer, Player secondPlayer); // Initialize the game field
    bool IsValidMove(int x, int y, Player CurrentPlayer, Player firstPlayer, Player secondPlayer); // Check if a move is valid

    void MarkCell(int x, int y, Player CurrentPlayer, Player firstPlayer, Player secondPlayer);
    bool HasEmptyCell();
    public (int, int) GetPoints(Player firstPlayer, Player secondPlayer);
}