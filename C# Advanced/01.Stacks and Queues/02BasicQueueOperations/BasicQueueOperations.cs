using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split();
            var numbers = Console.ReadLine().Split();

            Queue<int> queue = new Queue<int>();

            int countOfAddedElements = int.Parse(line[0]);
            int countOfRemovedElements = int.Parse(line[1]);
            int searchedNum = int.Parse(line[2]);

            for (int i = 0; i < countOfAddedElements; i++)
            {
                queue.Enqueue(int.Parse(numbers[i]));
            }

            for (int i = 1; i <= countOfRemovedElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchedNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count>0)
                {
                    var array = queue.ToArray();
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
