using System;
using System.Collections.Generic;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    public class Cat : Feline
    {
        private const double MealMass = 0.30;

        public Cat(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override List<Type> FoodMeals { get => this.foodMeals; protected set => this.foodMeals = new List<Type> { typeof(Meat), typeof(Vegetable) }; }

        public override void GrowWeight(int foodQantity)
        {
            this.Weight += foodQantity * MealMass;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
       
    }
}
