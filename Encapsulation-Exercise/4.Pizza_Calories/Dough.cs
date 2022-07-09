using System;
using System.Collections.Generic;

namespace _4.Pizza_Calories
{
    public class Dough
    {
        private int grams;
        private string type;
        private string bakingTech;

        private Dictionary<string, double> modifierTypeDough = new Dictionary<string, double>
            {
                {"white", 1.5 },
                {"wholegrain",1.0 }
            };
        private Dictionary<string, double> modifierBakingTech = new Dictionary<string, double>
            {
                {"crispy",0.9 },
                {"chewy",1.1 },
                {"homemade",1.0 }
            };

        public Dough(int grams, string type, string bakinTech)
        {
            this.Type = type;
            this.Grams = grams;
            this.BakingTech = bakinTech;
        }
        public int Grams
        {
            get => this.grams;
            private set
            {
                if (value > 0 && value <= 200)
                {
                    this.grams = value;
                }
                else
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
            }
        }
        public string Type
        {
            get => this.type;
            private set
            {
                if (modifierTypeDough.ContainsKey(value))
                {
                    this.type = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }
        public string BakingTech
        {
            get => this.bakingTech;
            private set 
            {
                if (modifierBakingTech.ContainsKey(value))
                {
                    this.bakingTech = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }
        public double Calories()
        {
            double result = 2 * this.grams * modifierTypeDough[this.type] * modifierBakingTech[this.bakingTech];
            return result;
        }
    }
}
