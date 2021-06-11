using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }


        public void AddFish(IFish fish)
        {
            if (Fish.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} {this.GetType().Name}");
            if (Fish.Count == 0)
            {
                result.AppendLine("Fish: none");
            }
            else
            {
                result.AppendLine($"Fish: {string.Join(", ", Fish.Select(x => x.Name))}");
            }
            result.AppendLine($"Decorations: {Decorations.Count}");
            result.AppendLine($"Comfort: {Comfort}");

            return result.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
    }
}
