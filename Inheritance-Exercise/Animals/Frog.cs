using System;

namespace Animals
{
    public class Frog : Animal, ICry
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public string ProduceSound()
        {
            return "Ribbit";
        }
        public override string ToString()
        {
            return $"Frog{Environment.NewLine}" +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
