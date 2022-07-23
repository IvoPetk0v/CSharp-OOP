namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Tiger : Feline
    {
        private const double MealMass = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override double WeightMultiplier { get => MealMass; }
        protected override IReadOnlyCollection<Type> FoodMeals => new List<Type> { typeof(Meat) }.AsReadOnly();

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
