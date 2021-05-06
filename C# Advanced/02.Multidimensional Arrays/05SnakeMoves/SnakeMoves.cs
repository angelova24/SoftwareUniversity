using System;
using System.Linq;

namespace _05SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            try
            {
                var dim = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                string snake = Console.ReadLine();
                char[,] matrix = new char[dim[0], dim[1]];
                int index = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                        matrix[row, col] = snake[index];
                        index++;
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                throw;
            }
            
        }
    }
}
