using System;

namespace Animals
{
    public class Dog:Animal,ICry
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"Dog{Environment.NewLine}" +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
