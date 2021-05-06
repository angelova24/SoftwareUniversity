using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private double whiteModifier = 1.5;
        private double wholegrainModifier = 1;
        private double crispyModifier = 0.9;
        private double chewyModifier = 1.1;
        private double homemadeModifier = 1;
        private double minGrams = 1;
        private double maxGrams = 200;
        private double grams;
        private string flourType;
        private string bakingTechnique;
        private double flourModifier;
        private double bakingTechniqueModifier;


        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }
        public double Grams
        {
            get => this.grams;
            set
            {
                if (value < minGrams || value > maxGrams)
                {
                    throw new Exception($"Dough weight should be in the range [{minGrams}..{maxGrams}].");
                }

                this.grams = value;
            }
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;

                if (value.ToLower() == "white")
                {
                    this.flourModifier = whiteModifier;
                }
                else
                {
                    this.flourModifier = wholegrainModifier;
                }
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" &&
                    value.ToLower() != "chewy" &&
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;

                if (value.ToLower() == "crispy")
                {                
                    bakingTechniqueModifier = crispyModifier;
                }
                else if (value.ToLower() == "chewy")
                {
                    bakingTechniqueModifier = chewyModifier;
                }
                else
                {
                    bakingTechniqueModifier = homemadeModifier;
                }
            }
        }

        public double CalculateCalories()
        {
            double result = 2 * this.grams * flourModifier * bakingTechniqueModifier;
            return result;
        }
    }

}
