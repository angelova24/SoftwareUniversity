using System;
using System.Collections.Generic;
using System.Linq;

namespace _09SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> results = new Stack<string>();
            string text = string.Empty;
            results.Push(text);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                if (input[0]=="4" && results.Count > 0)
                {
                    results.Pop();
                    text = results.Peek();
                }
                else
                {
                    if (input[0] == "1")
                    {
                        text += input[1];
                        results.Push(text);
                    }
                    else if (input[0] == "2")
                    {
                        int count = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - count);
                        results.Push(text);
                    }
                    else if (input[0] == "3")
                    {
                        int index = int.Parse(input[1]) - 1;
                        Console.WriteLine(text[index]);
                    }
                }
            }
        }
    }
}
