using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private double meatModifier = 1.2;
        private double veggiesModifier = 0.8;
        private double cheeseModifier = 1.1;
        private double sauceModifier = 0.9;
        private string type;
        private double grams;
        private double typeModifier;
        private double minGrams = 1;
        private double maxGrams = 50;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");            
                }

                this.type = value;

                if (value.ToLower() == "meat")
                {
                    typeModifier = meatModifier;
                }
                else if (value.ToLower() == "veggies")
                {
                    typeModifier = veggiesModifier;
                }
                else if (value.ToLower() == "cheese")
                {
                    typeModifier = cheeseModifier;
                }
                else if (value.ToLower() == "sauce")
                {
                    typeModifier = sauceModifier;
                }
            }
        }
        public double Grams
        {
            get => this.grams;
            set
            {
                if (value < minGrams || value > maxGrams)
                {
                    throw new Exception($"{this.type} weight should be in the range [{minGrams}..{maxGrams}].");
                }

                this.grams = value;
            }
        }
        public double CalculateCalories()
        {
            double result = 2 * grams * typeModifier;
            return result;
        }
    }
}
