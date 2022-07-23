namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Dog : Mammal
    {
        private const double MealMass = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier { get => MealMass; }
        protected override IReadOnlyCollection<Type> FoodMeals => new List<Type> { typeof(Meat) }.AsReadOnly();

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
