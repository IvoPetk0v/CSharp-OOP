using System;

namespace Animals
{
    class Kitten : Cat, ICry
    {
        private const string DeFGender = "Female";
        public Kitten(string name, int age) : base(name, age, DeFGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return $"Kitten{Environment.NewLine}" +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}

