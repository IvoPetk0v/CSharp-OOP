using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _4.Pizza_Calories
{
    public class Topping
    {
        private Dictionary<string, double> modifierType = new Dictionary<string, double>
            {
                {"Meat", 1.2 },
                {"Veggies",0.8 },
                {"Cheese",1.1 },
                {"Sauce",0.9 }
            };
        private string type;
        private int grams;
        public Topping(string type, int grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        public int Grams
        {
            get => this.grams;
            private set
            {
                if (value > 0 && value <= 50)
                {
                    this.grams = value;
                }
                else
                {
                    throw new Exception($"{this.type} weight should be in the range [1..50].");
                }
            }
        }
        public string Type
        {
            get => this.type;
            private set
            {
                char newChar = char.ToUpper(value.First());
                value = value.Remove(0, 1);
                value = value.Insert(0, newChar.ToString());
                if (modifierType.ContainsKey(value))
                {

                    this.type = value;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double Calories()
        {
            double result = 2 * grams * modifierType[this.type];
            return result;
        }
    }
}
