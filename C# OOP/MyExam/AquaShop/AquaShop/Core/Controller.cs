using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private ICollection<IAquarium> aquariums;
        private IRepository<IDecoration> repository;
        public Controller()
        {
            aquariums = new List<IAquarium>();
            repository = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                var aquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                var aquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            else if (decorationType == "Ornament")
            {
                var decoration = new Ornament();
                repository.Add(decoration);

            }
            else if (decorationType == "Plant")
            {
                var decoration = new Plant();
                repository.Add(decoration);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = null;
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            else if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
              
            }

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (fish.SuitableAquarium != aquarium.GetType().Name)
            {
                return OutputMessages.UnsuitableWater;
            }
            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var value = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var findDecoration = repository.FindByType(decorationType);

            if (findDecoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.AddDecoration(findDecoration);
            repository.Remove(findDecoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var output = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                output.AppendLine(aquarium.GetInfo());
            }

            return output.ToString().TrimEnd();
        }
    }
}
