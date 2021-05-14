using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(input);
            Stack<int> items = new Stack<int>(input2);
            var materials = new Dictionary<string, int>();
            materials["Glass"] = 0;
            materials["Aluminium"] = 0;
            materials["Lithium"] = 0;
            materials["Carbon fiber"] = 0;

            while (liquids.Count>0 && items.Count>0)
            {
                int liquid = liquids.Dequeue();
                int item = items.Pop();
                int sum = liquid + item;

                if (sum==25)
                {
                    materials["Glass"]++;
                }
                else if (sum == 50)
                {
                    materials["Aluminium"]++;
                }
                else if (sum == 75)
                {
                    materials["Lithium"]++;
                }
                else if (sum == 100)
                {
                    materials["Carbon fiber"]++;
                }
                else
                {
                    items.Push(item+3);
                }
            }

            if (materials.ContainsValue(0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            if (liquids.Count>0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in materials.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
