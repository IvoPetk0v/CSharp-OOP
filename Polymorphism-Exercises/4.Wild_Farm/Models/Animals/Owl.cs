using System;
using System.Collections.Generic;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        private const double MealMass = 0.25;

        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {

        }

        public override List<Type> FoodMeals { get => this.foodMeals; protected set => this.foodMeals = new List<Type> { typeof(Meat) }; }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
        public override void GrowWeight(int foodQantity)
        {
            this.Weight += foodQantity * MealMass;
        }
    }
}
