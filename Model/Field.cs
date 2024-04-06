namespace Othello.Model;
using Abstractions;

public class Field : IField
{
    private const int DefaultSize = 8;
    private Cell[,] field;
    private IField _fieldImplementation;

    public int FieldSize => DefaultSize;

    public Field()
    {
        field = new Cell[FieldSize, FieldSize];
        for (var x = 0; x < FieldSize; x++)
        {
            for (var y = 0; y < FieldSize; y++)
            {
                field[x, y] = new Cell();
            }
        }
    }

    public void InitializeField(Player CurrentPlayer,Player firstPlayer, Player secondPlayer)
    {
        field = new Cell[FieldSize, FieldSize];
        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                field[x, y] = new Cell();
            }
        }
            
        int mid = FieldSize / 2;
        field[mid - 1, mid - 1].MarkBy(secondPlayer);
        field[mid - 1, mid].MarkBy(firstPlayer);
        field[mid, mid - 1].MarkBy(firstPlayer);
        field[mid, mid].MarkBy(secondPlayer);
            
        CalculateAndSetPossibleMoves( CurrentPlayer, firstPlayer,  secondPlayer);
    }
    
    private void CalculateAndSetPossibleMoves(Player CurrentPlayer,Player firstPlayer, Player secondPlayer)
    {
        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                    
                field[x, y].IsPossibleMove = IsValidMove(x, y ,CurrentPlayer,firstPlayer,secondPlayer);
                    
            }
        }
    }

    public bool HasEmptyCell()
    {
        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                if (!field[x, y].IsEmpty)
                {
                    return true;
                }
                
            }
        }

        return false;
    }

    public (int, int) GetPoints(Player firstPlayer, Player secondPlayer )
    {
        var firstPlayerCount = 0;
        var secondPlayerCount = 0;
        

        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                if (field[x, y].MarkedByPlayer == firstPlayer)
                {
                    firstPlayerCount++;
                }
                else if (field[x, y].MarkedByPlayer == secondPlayer)
                {
                    secondPlayerCount++;
                }
                
            }
        }

        return (firstPlayerCount, secondPlayerCount);
    }
    

    public int Size { get; }

    public Cell[,] GetField()
    {
        return field.Clone() as Cell[,];
    }

    
    public bool IsValidMove(int x, int y, Player CurrentPlayer, Player firstPlayer, Player secondPlayer)
    {
        if (x < 0 || x >= FieldSize || y < 0 || y >= FieldSize || !field[x, y].IsEmpty)
        {
            return false;
        }

        Player currentPlayerMarker = (CurrentPlayer == firstPlayer) ? firstPlayer : secondPlayer;
        Player opponentMarker = (CurrentPlayer == firstPlayer) ? secondPlayer : firstPlayer;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }

                int r = x + i;
                int c = y + j;
                bool foundOpponentPiece = false;

                while (r >= 0 && r < FieldSize && c >= 0 && c < FieldSize &&
                       field[r, c].MarkedByPlayer == opponentMarker)
                {
                    r += i;
                    c += j;
                    foundOpponentPiece = true;
                }

                if (foundOpponentPiece && r >= 0 && r < FieldSize && c >= 0 && c < FieldSize &&
                    field[r, c].MarkedByPlayer == currentPlayerMarker && (r != x + i || c != y + j))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void MarkCell(int x, int y, Player CurrentPlayer, Player firstPlayer, Player secondPlayer)
    {
        field[x, y].MarkBy(CurrentPlayer);
        Player opponent = (CurrentPlayer == firstPlayer) ? secondPlayer : firstPlayer;
        List<(int, int)> directions = new List<(int, int)>
        {
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1),           (0, 1),
            (1, -1), (1, 0), (1, 1)
        };

        foreach (var (dx, dy) in directions)
        {
            int row = x + dx;
            int col = y + dy;
            bool foundOpponentPiece = false;

            while (row >= 0 && row < FieldSize && col >= 0 && col < FieldSize &&
                   field[row, col].MarkedByPlayer == opponent)
            {
                foundOpponentPiece = true;
                row += dx;
                col += dy;
            }

            if (foundOpponentPiece && row >= 0 && row < FieldSize && col >= 0 && col < FieldSize &&
                field[row, col].MarkedByPlayer == CurrentPlayer)
            {
                // Flip the opponent's pieces between (x, y) and (row, col)
                int r = x + dx;
                int c = y + dy;
                while (r != row || c != col)
                {
                    field[r, c].MarkBy(CurrentPlayer);
                    r += dx;
                    c += dy;

                    // Terminate the loop when reaching the destination cell
                    if (r == row && c == col)
                    {
                        break;
                    }
                }
            }
        }

        CalculateAndSetPossibleMoves(CurrentPlayer, firstPlayer, secondPlayer);
    }
    
    
    

}