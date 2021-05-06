using System;
using System.Linq;

namespace _06BombTheBasement
{
    class BombTheBasement
    {
        static void Main(string[] args)
        {
            int[] dim = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dim[0], dim[1]];

            int[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int bombRow = info[0];
            int bombCol = info[1];
            int radius = info[2];

            matrix[bombRow, bombCol] = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Pow((i - bombRow), 2) + Math.Pow((j - bombCol), 2) <= Math.Pow(radius, 2))
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 0)
                    {
                        for (int i = row; i < matrix.GetLength(0); i++)
                        {
                            if (matrix[i,col] == 1)
                            {
                                matrix[row,col] = 1;
                                matrix[i,col] = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
