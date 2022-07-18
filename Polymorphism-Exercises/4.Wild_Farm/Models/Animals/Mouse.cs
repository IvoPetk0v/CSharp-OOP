
using System;
using System.Collections.Generic;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MealMass = 0.10;

        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override List<Type> FoodMeals { get => this.foodMeals; protected set => this.foodMeals = new List<Type> {  typeof(Fruit), typeof(Vegetable) }; }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override void GrowWeight(int foodQantity)
        {
            this.Weight += foodQantity * MealMass;
        }
    }
}
