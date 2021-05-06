using System;

namespace _07KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int count = 0;
            if (n <= 3)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    if (matrix[i, j] == 'K')
                    {
                        if (matrix[i + 2, j + 1] == 'K')
                        {
                            matrix[i + 2, j + 1] = '0';
                            count++;
                        }
                        if (matrix[i + 1, j + 2] == 'K')
                        {
                            matrix[i + 1, j + 2] = '0';
                            count++;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                if (matrix[row, n - 2] == 'K')
                {
                    if (matrix[row + 2, n - 1] == 'K')
                    {
                        matrix[row + 2, n - 1] = '0';
                        count++;
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                if (matrix[n - 2, col] == 'K')
                {
                    if (matrix[n - 1, col + 2] == 'K')
                    {
                        matrix[n - 1, col + 2] = '0';
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
