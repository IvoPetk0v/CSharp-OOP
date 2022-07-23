namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Foods;

    public abstract class Animal
    {
        private const double MealMass = 1;
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public virtual double WeightMultiplier { get => MealMass; }
        public string Name { get; private set; }
        public double Weight { get; protected  set; }
        public int FoodEaten { get; protected set; }
        protected abstract  IReadOnlyCollection<Type> FoodMeals { get;}
        public  abstract string ProduceSound();
        public  void Eat(Food food)
        {
            if (!this.FoodMeals.Contains(food.GetType()))
            {
                throw new Exception($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
    }
}
