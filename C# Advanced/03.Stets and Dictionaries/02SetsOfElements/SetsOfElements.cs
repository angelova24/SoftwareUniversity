using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            var count = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstHashSet= new HashSet<int>();
            HashSet<int> secondHashSet= new HashSet<int>();

            for (int i = 0; i < count[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstHashSet.Add(number);
            }

            for (int i = 0; i < count[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondHashSet.Add(number);
            }

            foreach (var i in firstHashSet)
            {
                if (secondHashSet.Contains(i))
                {
                    Console.Write(i+" ");
                }
            }
        }
    }
}
