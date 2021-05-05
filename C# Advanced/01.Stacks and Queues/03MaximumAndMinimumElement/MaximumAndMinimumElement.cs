using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= count; i++)
            {
                string command = Console.ReadLine();

                if (command == "2")
                {
                    if (stack.Count>0)
                    {
                        stack.Pop();
                    }                   
                }
                else if (command == "3")
                {
                    if (stack.Count > 0)
                    {
                        var maxValue = stack.ToArray().Max();
                        Console.WriteLine(maxValue);
                    }
                }
                else if (command == "4")
                {
                    if (stack.Count > 0)
                    {
                        var minValue = stack.ToArray().Min();
                        Console.WriteLine(minValue);
                    }
                }
                else
                {
                    var array = command.Split();
                    int numToAdd = int.Parse(array[1]);
                    stack.Push(numToAdd);
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
