﻿namespace Wild_Farm.Factories
{
    using System;
    using Interfaces;
    using Models.Foods;

    class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            Food food;
            if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type=="Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new Exception("wrong type of food");
            }
            return food;
        }
    }
}
