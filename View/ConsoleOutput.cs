using Othello.Abstractions;

namespace Othello.View;
using Model;

public class ConsoleOutput
{
    private Events game;
    
    public void ListenTo(Events game)
    {
        this.game = game;
        game.GameStarted += OnGameStarted;
        game.FieldUpdated += RenderGameBoardWithPossibleMoves;
        game.PlayerWon += OnPlayerWon;
        game.MatchDrawn += OnMatchDrawn;
    }

    private void OnMatchDrawn()
    {
        Console.WriteLine("Game is over! It's a draw.");
    }

    private void OnPlayerWon(Player player)
    {
        Console.WriteLine($"Game is over! Player {player.Name} won!");
    }

    
    
    public void RenderGameBoardWithPossibleMoves(Cell[,] field)
    {
        
        for (int x = 0; x < field.GetLength(0); x++)
        {
            for (int y = 0; y < field.GetLength(1); y++)
            {
                if (field[x, y].IsPossibleMove)
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write(GetCellValue(field[x, y]) + " ");
                }
            }
            Console.WriteLine();
        }
        
    }

    private string GetCellValue(Cell cell)
    {
        return cell.IsEmpty ? " " : cell.MarkedByPlayer.Name;
    }

    private void OnGameStarted(Cell[,] field)
    {
        
        Console.WriteLine("Game is started! Make your first move with 'MOVE X Y'");
        
    }

    
}