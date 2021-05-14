using System;

namespace _02.KnightsОfHonor
{
    class KnightsОfHonor
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names =>
                Console.Write("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            string[] inputNames = Console.ReadLine()
                .Split();

            printNames(inputNames);
        }
    }
}
