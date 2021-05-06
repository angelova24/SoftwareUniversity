using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private const int nameMinLength = 1;
        private const int nameMaxLength = 15;
        private List<Topping> toppings;
        private string name;
        private Dough dough;
        public Pizza(string name, Dough dough)
        {
            this.toppings = new List<Topping>();
            this.Name = name;
            this.dough = dough;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > nameMaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {nameMinLength} and {nameMaxLength} symbols.");
                }

                this.name = value;
            }
        }

        public double CalculateCalories()
        {
            double result = this.dough.CalculateCalories() + this.toppings.Sum(t => t.CalculateCalories());
            return result;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateCalories():f2} Calories.";
        }
    }
}
