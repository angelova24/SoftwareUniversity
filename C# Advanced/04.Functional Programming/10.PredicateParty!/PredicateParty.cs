using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, int, bool> lengthFilter = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);

            Func<List<string>, List<string>, List<string>> doublePeople = (a, b) =>
            {
                foreach (string doubled in b)
                {
                    for (int i = 0; i < a.Count * 2; i++)
                    {
                        if (i < a.Count)
                        {
                            if (a[i] == doubled)
                            {
                                a.Insert(i, doubled);
                                i++;
                            }
                        }
                    }
                }

                return a;
            };
            List<string> filtered = new List<string>();

            string filter;

            while ((filter = Console.ReadLine()) != "Party!")
            {
                var filterInfo = filter.Split();

                if (filterInfo[1] == "StartsWith")
                {
                    filtered = names
                        .Where(name => startsWithFilter(name, filterInfo[2]))
                        .Distinct()
                        .ToList();
                }

                else if (filterInfo[1] == "EndsWith")
                {
                    filtered = names
                        .Where(name => endsWithFilter(name, filterInfo[2]))
                        .Distinct()
                        .ToList();
                }

                else if (filterInfo[1] == "Length")
                {
                    filtered = names
                        .Where(name => lengthFilter(name, int.Parse(filterInfo[2])))
                        .Distinct()
                        .ToList();
                }

                switch (filterInfo[0])
                {
                    case "Remove":
                        names = names
                            .Where(p => !filtered.Contains(p))
                            .ToList();
                        break;
                    case "Double":
                        names = doublePeople(names, filtered);
                        break;
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}