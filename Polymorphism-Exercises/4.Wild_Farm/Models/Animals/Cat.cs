namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Cat : Feline
    {
        private const double MealMass = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight,livingRegion, breed)
        {
        }
        public override double WeightMultiplier { get => MealMass; }
        protected override IReadOnlyCollection<Type> FoodMeals => new List<Type> { typeof(Meat), typeof(Vegetable) }.AsReadOnly();
   
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
