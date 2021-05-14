using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> input = new Stack<string>(line);

            var halls = new Queue<string>();
            var currentCapacity = new List<int>();
            while (input.Count > 0)
            {
                string current = input.Peek();
                int reservation = 0;
                if (int.TryParse(current, out reservation))
                {
                    if (halls.Count > 0 && currentCapacity.Sum() + reservation <= maxCapacity)
                    {
                        currentCapacity.Add(reservation);
                        if (currentCapacity.Sum()==maxCapacity)
                        {
                            Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", currentCapacity)}");
                            currentCapacity.Clear();
                        }
                    }
                    else if (halls.Count > 0 && currentCapacity.Sum() + reservation > maxCapacity)
                    {
                        if (halls.Count>1)
                        {
                            Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", currentCapacity)}");
                            currentCapacity.Clear();
                            currentCapacity.Add(reservation);
                        }

                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", currentCapacity)}");
                        currentCapacity.Clear();
                    }
                }
                else
                {
                    halls.Enqueue(current);
                }

                input.Pop();
            }
        }
    }
}
