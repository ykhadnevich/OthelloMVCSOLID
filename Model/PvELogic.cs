using Othello.Abstractions;
using System;

namespace Othello.Model
{
    public class PvELogic : Player
    {
        private readonly Random rand;

        public PvELogic(string name) : base(name)
        {
            rand = new Random((int)DateTime.Now.Ticks);
        }

        public override void MakeMove(IField gameField, Player firstPlayer, Player secondPlayer)
        {
            (int, int) coords = GenerateRandomMove(gameField, firstPlayer, secondPlayer);
            gameField.MarkCell(coords.Item1, coords.Item2, this, firstPlayer, secondPlayer);
        }

        public (int, int) GenerateRandomMove(IField gameField, Player firstPlayer, Player secondPlayer)
        {
            int size = gameField.Size;
            int x, y;

            do
            {
                x = rand.Next(0, size);
                y = rand.Next(0, size);
                Console.WriteLine(x + " " + y + " " + !gameField.IsValidMove(x, y, this, firstPlayer, secondPlayer));
            } while (!gameField.IsValidMove(x, y, this, firstPlayer, secondPlayer));

            return (x, y);
        }
    }
}