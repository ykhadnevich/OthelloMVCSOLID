namespace Othello.Abstractions;

public abstract class Player
{
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
    }
    public abstract void MakeMove(IField gameField, Player firstPlayer, Player secondPlayer);
}