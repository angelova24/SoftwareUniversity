using System;
using System.Linq;

namespace _04MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dim = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[dim[0], dim[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] swap = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (swap[0]=="swap" && swap.Count()==5)
                {
                    int row1 = int.Parse(swap[1]);
                    int col1 = int.Parse(swap[2]);
                    int row2 = int.Parse(swap[3]);
                    int col2 = int.Parse(swap[4]);

                    if (row1<dim[0] && row2<dim[0] && col1<dim[1] && col2<dim[1])
                    {
                        string oldCell = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = oldCell;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(matrix[i,j]+" ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
