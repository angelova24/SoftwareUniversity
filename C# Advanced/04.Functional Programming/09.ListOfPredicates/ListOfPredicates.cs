﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());

            List<int> numbers = Enumerable.Range(1, upperBound).ToList();

            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var currentNumber in inputNumbers)
            {
                predicates.Add(x => x % currentNumber == 0);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                foreach (var currentPredicate in predicates)
                {
                    numbers = numbers.FindAll(currentPredicate);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
