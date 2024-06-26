﻿namespace Othello.Model;
using Abstractions;

public class Game : IGame
{
    private readonly IField gameField;
    private Player currentPlayer;
    private bool isEnded;
    private const int FieldSize = 8;
    
    public Player firstPlayer;
    public  Player secondPlayer;
    /*private Cell[,] field;*/
    public bool IsEnded
    {
        get => isEnded;
        set => isEnded = value;
    }

    public IField GetField()
    {
        return GameField;
    }
    
    public Player CurrentPlayer
    {
        get => currentPlayer;
        set => currentPlayer = value;
    }

    public Player Winner { get; protected set; }
    public IField GameField => gameField;
    public object Events { get; set; }

    public Game(IField gameField )
    {
        
        
        this.gameField = gameField;
        
        isEnded = false;
    }


    public virtual void Start(Player firstPlayer, Player secondPlayer)
    {
        this.firstPlayer = firstPlayer;
        this.secondPlayer = secondPlayer;
        CurrentPlayer = firstPlayer;
        GameField.InitializeField(CurrentPlayer,firstPlayer, secondPlayer);
        IsEnded = false;
    }


    public virtual void MakeMove()
    {
            
        if (IsEnded)
        {
            Console.WriteLine("Game is already ended.");
            return;
        }

        

        CurrentPlayer.MakeMove(GameField , firstPlayer ,secondPlayer);
        
        
            
        CheckGameEnd();
        SwitchPlayer();
    }
    
    public void CheckGameEnd()
    {
        
        var hasEmptyCells = GameField.HasEmptyCell();

        if (!hasEmptyCells)
        {
            var firstPlayerCount = GameField.GetPoints(firstPlayer ,secondPlayer).Item1;
            var secondPlayerCount = GameField.GetPoints(firstPlayer ,secondPlayer).Item2;;
            
            if (firstPlayerCount > secondPlayerCount)
            {
                EndGame(firstPlayer);
            }
            else if (secondPlayerCount > firstPlayerCount)
            {
                EndGame(secondPlayer);
            }
            else
            {
                EndGame(); // Game ends in a draw
            }
        }

        
    }
    protected virtual void EndGame(Player winner = null)
    {
        IsEnded = true;
        Winner = winner;
    }

    private void SwitchPlayer()
    {
        CurrentPlayer = (CurrentPlayer == firstPlayer) ? secondPlayer : firstPlayer;
    }
}