namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Owl : Bird
    {
        private const double MealMass = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }
        public override double WeightMultiplier { get => MealMass; }
        protected override IReadOnlyCollection<Type> FoodMeals => new List<Type> { typeof(Meat) }.AsReadOnly();
       
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
       
    }
}
