using System;
using System.ComponentModel.Design;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int firstPlayerRow = 0;
            int firstPlayerCol = 0;
            int secondPlayerRow = 0;
            int secondPlayerCol = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                    if (input[j] == 'f')
                    {
                        firstPlayerRow = i;
                        firstPlayerCol = j;
                    }
                    else if (input[j] == 's')
                    {
                        secondPlayerRow = i;
                        secondPlayerCol = j;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();
                string firstCommand = command[0];
                string secondCommand = command[1];

                //First Player
                if (firstCommand == "down")
                {
                    firstPlayerRow += 1;
                    if (firstPlayerRow>matrix.GetLength(0))
                    {
                        firstPlayerRow = 0;
                    }
                }
                else if (firstCommand == "up")
                {
                    firstPlayerRow -= 1;
                    if (firstPlayerRow<0)
                    {
                        firstPlayerRow = matrix.GetLength(0);
                    }
                }
                else if (firstCommand == "left")
                {
                    firstPlayerCol -= 1;
                    if (firstPlayerCol<0)
                    {
                        firstPlayerCol = matrix.GetLength(1);
                    }
                }
                else if (firstCommand == "right")
                {
                    firstPlayerCol += 1;
                    if (firstPlayerCol>matrix.GetLength(1))
                    {
                        firstPlayerCol = 0;
                    }
                }

                char firstPosition = matrix[firstPlayerRow, firstPlayerCol];
                if (firstPosition=='*')
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }
                else if (firstPosition=='s')
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x';
                    break;
                }

                //Second Player

                if (secondCommand == "down")
                {
                    secondPlayerRow += 1;
                    if (secondPlayerRow > matrix.GetLength(0))
                    {
                        secondPlayerRow = 0;
                    }
                }
                else if (secondCommand == "up")
                {
                    secondPlayerRow -= 1;
                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = matrix.GetLength(0);
                    }
                }
                else if (secondCommand == "left")
                {
                    secondPlayerCol -= 1;
                    if (secondPlayerCol < 0)
                    {
                        secondPlayerCol = matrix.GetLength(1);
                    }
                }
                else if (secondCommand == "right")
                {
                    secondPlayerCol += 1;
                    if (secondPlayerCol > matrix.GetLength(1))
                    {
                        secondPlayerCol = 0;
                    }
                }


                char secondPosition = matrix[secondPlayerRow, secondPlayerCol];
                if (secondPosition == '*')
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }
                else if (secondPosition == 'f')
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    break;
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
