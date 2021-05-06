using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInfo = Console.ReadLine().Split();
                var doughInfo = Console.ReadLine().Split();

                var pizzaName = pizzaInfo[1];

                var doughType = doughInfo[1];
                var doughBacking = doughInfo[2];
                var doughGrams = double.Parse(doughInfo[3]);

                var dough = new Dough(doughType, doughBacking, doughGrams);
                var pizza = new Pizza(pizzaName, dough);

                
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "END")
                    {
                        Console.WriteLine(pizza.ToString());
                        return;
                    }
                    var toppingInfo = input.Split();

                    var toppingType = toppingInfo[1];
                    var toppingGrams = double.Parse(toppingInfo[2]);
                    var topping = new Topping(toppingType, toppingGrams);
                    pizza.AddTopping(topping);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
