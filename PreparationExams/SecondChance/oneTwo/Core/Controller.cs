using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decoration;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decoration = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }

            throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType is nameof(Ornament))
            {
                this.decoration.Add(new Ornament());
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType is nameof(Plant))
            {
                this.decoration.Add(new Plant());
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }


            throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (this.decoration.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,
                    decorationType));
            }
            this.aquariums.First(a => a.Name == aquariumName)
                    .AddDecoration(this.decoration.FindByType(decorationType));
            this.decoration.Remove(this.decoration.FindByType(decorationType));
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {

            if (fishType is nameof(FreshwaterFish))
            {
                if (aquariums.First(x => x.Name == aquariumName).GetType().Name is nameof(FreshwaterAquarium))
                {
                    aquariums.First(x => x.Name == aquariumName).AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                    return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else if (aquariums.First(x => x.Name == aquariumName).GetType().Name is nameof(SaltwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else if (fishType is nameof(SaltwaterFish))
            {
                if (aquariums.First(x => x.Name == aquariumName).GetType().Name is nameof(SaltwaterAquarium))
                {
                    aquariums.First(x => x.Name == aquariumName).AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                    return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else if (aquariums.First(x => x.Name == aquariumName).GetType().Name is nameof(FreshwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }

            throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
        }

        public string FeedFish(string aquariumName)
        {
            this.aquariums.First(x => x.Name == aquariumName).Feed();
            string fishFed = this.aquariums.First(x => x.Name == aquariumName).Fish.Count().ToString();
            return string.Format(OutputMessages.FishFed, fishFed);
        }

        public string CalculateValue(string aquariumName)
        {
            var aqurium = this.aquariums.First(x => x.Name == aquariumName);
            decimal result = aqurium.Fish.Sum(f => f.Price) + aqurium.Decorations.Sum(d => d.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, result);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
