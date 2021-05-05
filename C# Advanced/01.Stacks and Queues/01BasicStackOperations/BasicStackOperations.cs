using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split();
            var numbers = Console.ReadLine().Split();

            int countOfPushedElements = int.Parse(line[0]);
            int countOfPopedElements = int.Parse(line[1]);
            int searchedNum = int.Parse(line[2]);

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countOfPushedElements; i++)
            {
                stack.Push(int.Parse(numbers[i]));
            }

            for (int i = 1; i <= countOfPopedElements; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(searchedNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                var array = stack.ToArray();
                if (array.Length > 0)
                {
                    int minValue = array.Min();
                    Console.WriteLine(minValue);
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
