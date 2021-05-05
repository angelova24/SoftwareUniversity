using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> givenPetrol = new List<int>(n);
            List<int> distanceToTheNextPump = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                var info = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int petrol = info[0];
                int distance = info[1];

                givenPetrol.Add(petrol);
                distanceToTheNextPump.Add(distance);
            }
            int startPosition = 0;
            int currentPetrol = 0;
            while (true)
            {
                bool finish = false;
                for (int i = startPosition; i < n + startPosition; i++)
                {
                    if (currentPetrol + givenPetrol[i % n] - distanceToTheNextPump[i % n] >= 0)
                    {
                        currentPetrol += givenPetrol[i % n] - distanceToTheNextPump[i % n];
                        finish = true;
                    }
                    else
                    {
                        startPosition++;
                        currentPetrol = 0;
                        finish = false;
                        break;
                    }
                }
                if (finish)
                {
                    Console.WriteLine(startPosition);
                    return;
                }
            }
        }
    }
}
