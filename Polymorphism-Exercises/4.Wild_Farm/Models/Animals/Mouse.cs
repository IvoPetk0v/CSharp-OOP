namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Mouse : Mammal
    {
        private const double MealMass = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override double WeightMultiplier { get => MealMass; }
        protected override IReadOnlyCollection<Type> FoodMeals => new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();
       
        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
