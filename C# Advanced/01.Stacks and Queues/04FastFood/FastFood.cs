using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            var ordersInArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int biggestOrder=0;

            Queue<int> orders = new Queue<int>(ordersInArray.Length);

            for (int i = 0; i < ordersInArray.Length; i++)
            {
                orders.Enqueue(ordersInArray[i]);
            }

            while (orders.Count>0)
            {
                int currentOrder = orders.Peek();

                if (quantity-currentOrder>=0)
                {
                    quantity -= currentOrder;
                    if (currentOrder>biggestOrder)
                    {
                        biggestOrder = currentOrder;
                    }
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine(biggestOrder);
                    Console.Write("Orders left: ");
                    while (orders.Count>0)
                    {
                        Console.Write(orders.Dequeue()+" ");
                    }
                    return;
                }
            }
            Console.WriteLine(biggestOrder);
            Console.WriteLine("Orders complete");
        }
    }
}
