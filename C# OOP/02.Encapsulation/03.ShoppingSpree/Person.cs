using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void Buy(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new Exception($"{this.Name} can't afford {product.Name}");
            }

            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(p => p.Name))}";
        }

    }
}
