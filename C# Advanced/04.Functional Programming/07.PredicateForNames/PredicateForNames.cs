using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> isLower = x => x.Length <= length;

            Console.ReadLine()
                .Split()
                .Where(x => isLower(x))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}