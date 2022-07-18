
using System;
using System.Collections.Generic;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {
        private const double MealMass = 0.35;

        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override List<Type> FoodMeals { get => this.foodMeals; protected set => this.foodMeals = new List<Type> { typeof(Seeds), typeof(Meat), typeof(Fruit), typeof(Vegetable) }; }

        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override void GrowWeight(int foodQantity)
        {
            this.Weight += foodQantity * MealMass;
        }
    }
}
