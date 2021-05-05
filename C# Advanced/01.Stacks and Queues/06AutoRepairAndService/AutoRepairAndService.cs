using System;
using System.Collections.Generic;

namespace _06AutoRepairAndService
{
    class AutoRepairAndService
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> carsForService = new Queue<string>(input.Length);
            Stack<string> servedCars = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                carsForService.Enqueue(input[i]);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string currentCar = string.Empty;
                var tryPeek = carsForService.TryPeek(out currentCar);
                if (command.Contains("Service") && carsForService.Count>0)
                {
                    servedCars.Push(currentCar);
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                    carsForService.Dequeue();
                }
                else if (command.Contains("CarInfo"))
                {
                    var info = command.Split('-');
                    string car = info[1];

                    if (servedCars.Contains(car))
                    {
                        Console.WriteLine("Served.");
                    }
                    else
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }
                else if (command.Contains("History"))
                {
                    Console.WriteLine(String.Join(", ", servedCars));
                }
                command = Console.ReadLine();
            }

            if (carsForService.Count > 0)
            {
                Console.Write("Vehicles for service: ");
                Console.WriteLine(String.Join(", ", carsForService));
            }

            Console.Write("Served vehicles: ");
            Console.WriteLine(String.Join(", ", servedCars));
        }
    }
}
