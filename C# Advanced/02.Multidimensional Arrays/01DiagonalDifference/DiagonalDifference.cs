using System;
using System.Linq;

namespace _01DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int primariDiagonalSum = 0;
            for (int row = 0; row < size; row++)
            {               
                    primariDiagonalSum += matrix[row, row];            
            }
            int secondaryDiagonalSum = 0;
            int col = 0;
            for (int row = size - 1; row >= 0; row--)
            {
                secondaryDiagonalSum += matrix[row, col];
                col++;
            }
            Console.WriteLine(Math.Abs(primariDiagonalSum-secondaryDiagonalSum));
        }
    }
}
