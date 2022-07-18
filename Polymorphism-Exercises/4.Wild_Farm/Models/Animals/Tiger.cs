
using System;
using System.Collections.Generic;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double MealMass = 1.00;

        public Tiger(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override List<Type> FoodMeals { get => this.foodMeals; protected set => this.foodMeals = new List<Type> { typeof(Meat) }; }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override void GrowWeight(int foodQantity)
        {
            this.Weight += foodQantity * MealMass;
        }
    }
}
