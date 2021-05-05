using System;
using System.Collections.Generic;

namespace _08BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length%2!=0)
            {
                Console.WriteLine("NO");
                return;
            }

            Queue<char> firstPart = new Queue<char>();
            Stack<char> secondPart = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (i<input.Length/2)
                {
                    firstPart.Enqueue(input[i]);
                }
                else
                {
                    secondPart.Push(input[i]);
                }
            }
            while (firstPart.Count>0)
            {
                if (firstPart.Peek() =='{' && secondPart.Peek()=='}')
                {
                    firstPart.Dequeue();
                    secondPart.Pop();
                }
                else if (firstPart.Peek() == '(' && secondPart.Peek() == ')')
                {
                    firstPart.Dequeue();
                    secondPart.Pop();
                }
                else if (firstPart.Peek() == '[' && secondPart.Peek() == ']')
                {
                    firstPart.Dequeue();
                    secondPart.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
