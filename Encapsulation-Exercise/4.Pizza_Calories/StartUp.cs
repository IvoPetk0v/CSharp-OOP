using System;

namespace _4.Pizza_Calories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaArgs = Console.ReadLine().Split();
            string[] doughArgs = Console.ReadLine().Split();

            int grams = int.Parse(doughArgs[3]);
            string type = doughArgs[1].ToLower();
            string bakingTech = doughArgs[2].ToLower();

            try
            {
                Dough newDough = new Dough(grams, type, bakingTech);
                Pizza newPizza = new Pizza(pizzaArgs[1], newDough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingIngreds = input.Split();
                    grams = int.Parse(toppingIngreds[2]);
                    type = toppingIngreds[1].ToLower();

                    Topping newTopping = new Topping(type, grams);
                    newPizza.AddTopping(newTopping);
                }
                Console.WriteLine($"{newPizza.Name} - {newPizza.Calories():f2} Calories.");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}

