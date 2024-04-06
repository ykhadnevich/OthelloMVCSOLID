namespace Othello.Abstractions;

public interface ICordinatesTaker
{
    public (int,int) GetPlayerCordinates(IField gameReversoField); 
}