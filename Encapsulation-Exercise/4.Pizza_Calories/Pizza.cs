using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Pizza_Calories
{
    public class Pizza 
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
      
        public Pizza(string pizzaName,Dough dough) 
        {
            this.Name = pizzaName;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                else if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough 
        {
            set
            {
                this.dough = value;
            }
        }
        public int ToppingsCount { get => this.toppings.Count; }
        public bool AddTopping(Topping topping)
        {
            if (toppings.Count<10)
            {
                toppings.Add(topping);
                return true;
            }
            throw new Exception("Number of toppings should be in range [0..10].");
        }
        public double Calories()
        {
            double result = this.dough.Calories();
            foreach (var topping in this.toppings)
            {
                result += topping.Calories();
            }
           
            return result;
        }

    }
}
