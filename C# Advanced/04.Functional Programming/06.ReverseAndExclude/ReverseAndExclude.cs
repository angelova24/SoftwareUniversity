using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int divisibleNumber = int.Parse(Console.ReadLine());
            Func<int, bool> divisibleFunc = x => x % divisibleNumber != 0;

            var result = inputNumbers.Where(divisibleFunc);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}