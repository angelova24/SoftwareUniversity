using System;
using System.Collections.Generic;

namespace _05CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            SortedDictionary<char,int> characters = new SortedDictionary<char, int>();

            var text = Console.ReadLine().ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (!characters.ContainsKey(text[i]))
                {
                    characters.Add(text[i], 0);
                }

                characters[text[i]]++;
            }

            foreach (var character in characters)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
