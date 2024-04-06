using Othello.Abstractions;

namespace Othello.Model;

public class Events : Game
{
    
    
    public event Action<Cell[,]> GameStarted;
        
    public event Action<Cell[,]> FieldUpdated;
        
    public event Action<Player> PlayerWon;
        
    public event Action MatchDrawn;
        
        
        
    public Events(IField gameField) : base(gameField)
    {
    }

    
    public override void Start(Player firstPlayer, Player secondPlayer)
    {
        base.Start( firstPlayer,  secondPlayer);
        FieldUpdated?.Invoke(base.GameField.GetField());
        GameStarted?.Invoke(base.GameField.GetField());
    }

    /*protected  void MarkCell(int x, int y, Player CurrentPlayer, Player firstPlayer, Player secondPlayer)
    {
        base.GetField();
        FieldUpdated?.Invoke(base.GameField.GetField());
    }*/

    public override void MakeMove()
    {
        base.MakeMove();
        FieldUpdated?.Invoke(GameField.GetField());
    }
    
    
    protected override void EndGame(Player winner = null)
    {
            
        base.EndGame(winner);
        IsEnded = true;
        Winner = winner;
        if (winner == null)
        {
            MatchDrawn?.Invoke();
        }
        else
        {
            PlayerWon?.Invoke(winner);
        }
    }
}