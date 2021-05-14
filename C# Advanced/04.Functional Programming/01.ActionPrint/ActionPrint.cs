using System;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names =>
                Console.Write(string.Join(Environment.NewLine, names));

            string[] inputNames = Console.ReadLine()
                .Split();

            printNames(inputNames);
        }
    }
}
