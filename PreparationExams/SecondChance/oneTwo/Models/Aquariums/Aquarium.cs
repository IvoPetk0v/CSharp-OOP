using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private readonly HashSet<IDecoration> decorations;
        private readonly HashSet<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new HashSet<IDecoration>();
            this.fish = new HashSet<IFish>();
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
        public int Comfort
        {
            get => this.decorations.Sum(x => x.Comfort);
            
        }
        public ICollection<IDecoration> Decorations
        {
            get => this.decorations;
            
        }
        public ICollection<IFish> Fish
        {
            get => this.fish;
           
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity >= this.fish.Count + 1)
            {
                this.fish.Add(fish);
                return;
            }

            throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string fishString = this.fish.Count == 0 ? "none" : string.Join(", ", this.fish.Select(x => x.Name));
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishString}");
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString();
        }
    }
}
