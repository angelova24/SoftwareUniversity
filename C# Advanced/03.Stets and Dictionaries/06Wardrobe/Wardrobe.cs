using System;
using System.Collections.Generic;

namespace _06Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var combi = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = combi[0];
                var clothes = combi[1].Split(",");

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[colour].ContainsKey(clothes[j]))
                    {
                        wardrobe[colour].Add(clothes[j],0);
                    }

                    wardrobe[colour][clothes[j]]++;
                }
            }

            var search = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColour = search[0];
            string searchedClothes = search[1];

            foreach (var deconstruction in wardrobe)
            {
                Console.WriteLine($"{deconstruction.Key} clothes:");
                foreach (var item in deconstruction.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");
                    if (deconstruction.Key==searchedColour && item.Key==searchedClothes)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
