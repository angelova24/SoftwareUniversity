using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            var box = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacityOfARack = int.Parse(Console.ReadLine());

            Stack<int> valuesOfClothes = new Stack<int>(box.Length);

            for (int i = 0; i < box.Length; i++)
            {
                valuesOfClothes.Push(box[i]);
            }

            int countOfRacks = 1;
            int currentCapacity = 0;
            while (valuesOfClothes.Count>0)
            {
                int currentValue = valuesOfClothes.Pop();

                if (currentCapacity+currentValue<=capacityOfARack)
                {
                    currentCapacity += currentValue;
                }
                else
                {
                    countOfRacks++;
                    currentCapacity = 0;
                    currentCapacity += currentValue;
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
