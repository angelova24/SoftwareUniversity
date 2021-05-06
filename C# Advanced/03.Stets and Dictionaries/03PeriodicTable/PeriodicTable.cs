using System;
using System.Collections.Generic;

namespace _03PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in input)
                {
                    elements.Add(s);
                }
            }

            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
