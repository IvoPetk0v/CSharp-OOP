using System;

namespace Animals
{
    public class Cat : Animal, ICry
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public virtual string ProduceSound()
        {
            return "Meow meow";
        }
        public override string ToString()
        {
            return $"Cat{Environment.NewLine}" +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
