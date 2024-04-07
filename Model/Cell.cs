namespace Othello.Model;
using Abstractions;

public class Cell
{
    public Player MarkedByPlayer { get; private set; }

    public bool IsEmpty => MarkedByPlayer == null;
        
    public bool IsPossibleMove { get; set; }

    public void MarkBy(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player), "Player cannot be null.");
        MarkedByPlayer = player;
    }
}