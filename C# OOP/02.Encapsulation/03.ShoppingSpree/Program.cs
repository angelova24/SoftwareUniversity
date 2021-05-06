using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();
            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var personAndProduct = input.Split();
                var personName = personAndProduct[0];
                var productName = personAndProduct[1];

                var person = people[personName];
                var product = products[productName];

                try
                {
                    person.Buy(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();

            var parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var personData = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }
            return result;
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();
            var parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var productInfo = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var productName = productInfo[0];
                var cost = decimal.Parse(productInfo[1]);

                result[productName] = new Product(productName, cost);
            }
            return result;
        }
    }
}
