using Othello.Abstractions;

namespace Othello.Controller;

public class CordinatesTaker : ICordinatesTaker
{
    public (int, int) GetPlayerCordinates(IField gameReversoField)
    {
        while (true)
        {
            string[] input = Console.ReadLine()?.Split();
            if (input != null && input.Length == 2 && int.TryParse(input[0], out int x) && int.TryParse(input[1], out int y))
            {
                return(x, y);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter your move in the format 'X Y'.");
            }
        }
    }
    
}