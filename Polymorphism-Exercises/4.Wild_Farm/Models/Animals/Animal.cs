namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
   
    public abstract class Animal
    {
        protected List<Type> foodMeals;
        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;

        }

        public string Name { get; private set; }
        public double Weight { get; protected  set; }
        public int FoodEaten { get; protected set; }
        public abstract List<Type> FoodMeals { get; protected set; }
        public  abstract string ProduceSound();
        public abstract void GrowWeight(int foodQantity);
    }
}
