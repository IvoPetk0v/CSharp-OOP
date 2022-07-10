using System;

namespace Animals
{
    public class Tomcat : Cat, ICry
    {
        private const string DeFGender = "Male";
        public Tomcat(string name, int age) : base(name, age, DeFGender)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
        public override string ToString()
        {
            return $"Tomcat{Environment.NewLine}" +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}

