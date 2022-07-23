namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Hen : Bird
    {
        private const double MealMass = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override double WeightMultiplier { get => MealMass; }
        protected override IReadOnlyCollection<Type> FoodMeals => new List<Type>
        { typeof(Seeds), typeof(Meat), typeof(Fruit), typeof(Vegetable) }
        .AsReadOnly();

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
