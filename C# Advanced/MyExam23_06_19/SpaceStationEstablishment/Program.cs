using System;
using System.Collections.Generic;
using System.Data;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] galaxy = new char[n][];
            var blackHoles = new List<int>();
            int spaceShipRow = 0;
            int spaceShipCol = 0;
            int starPower = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                galaxy[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    galaxy[row][col] = input[col];

                    if (input[col] == 'S')
                    {
                        spaceShipRow = row;
                        spaceShipCol = col;
                    }
                    else if (input[col] == 'O')
                    {
                        blackHoles.Add(row);
                        blackHoles.Add(col);
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();

                galaxy[spaceShipRow][spaceShipCol] = '-';

                if (direction == "up")
                {
                    spaceShipRow--;
                }
                else if (direction == "down")
                {
                    spaceShipRow++;
                }
                else if (direction == "right")
                {
                    spaceShipCol++;
                }
                else if (direction == "left")
                {
                    spaceShipCol--;
                }

                if (spaceShipRow < 0 || spaceShipRow == n || spaceShipCol < 0 || spaceShipCol == n)
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Console.WriteLine($"Star power collected: {starPower}");
                    foreach (var row in galaxy)
                    {
                        Console.WriteLine(string.Join("", row));
                    }
                    return;
                }

                if (blackHoles.Count > 0)
                {
                    if (spaceShipRow == blackHoles[0] && spaceShipCol == blackHoles[1])
                    {
                        galaxy[spaceShipRow][spaceShipCol] = '-';
                        spaceShipRow = blackHoles[2];
                        spaceShipCol = blackHoles[3];
                        galaxy[spaceShipRow][spaceShipCol] = 'S';
                        blackHoles.Clear();
                    }
                    else if (spaceShipRow == blackHoles[2] && spaceShipCol == blackHoles[3])
                    {
                        galaxy[spaceShipRow][spaceShipCol] = '-';
                        spaceShipRow = blackHoles[0];
                        spaceShipCol = blackHoles[1];
                        galaxy[spaceShipRow][spaceShipCol] = 'S';
                        blackHoles.Clear();
                    }
                }

                if (char.IsDigit(galaxy[spaceShipRow][spaceShipCol]))
                {
                    int star = int.Parse(galaxy[spaceShipRow][spaceShipCol].ToString());
                    starPower += star;
                    galaxy[spaceShipRow][spaceShipCol] = 'S';
                }

                if (starPower>=50)
                {
                    break;
                }
            }


            Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starPower}");

            foreach (var row in galaxy)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
