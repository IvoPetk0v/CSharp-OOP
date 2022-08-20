using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish:Fish
    {
        private const int InitializeSize = 3;
        private const int IncreaseSizeValue = 3;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = InitializeSize;
        }

        public override void Eat()
        {
            this.Size += IncreaseSizeValue;
        }
    }
}
