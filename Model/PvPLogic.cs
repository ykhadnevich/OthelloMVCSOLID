using Othello.Abstractions;

namespace Othello.Model;

public class PvPLogic : Player
{
    private ICordinatesTaker _cordinatesTaker;
    
    public PvPLogic(string name , ICordinatesTaker baseCordinatesTaker) : base(name)
    {
        _cordinatesTaker = baseCordinatesTaker;
    }

    public override void MakeMove(IField gameField, Player firstPlayer, Player secondPlayer)
    {
        (int,int) cords = _cordinatesTaker.GetPlayerCordinates(gameField);
        
        gameField.MarkCell(cords.Item1 ,cords.Item2 , this , firstPlayer ,secondPlayer);
    }
    
    
    
}