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
            Pizza newPizza;
            try
            {

                Dough newDough = new Dough(grams, type, bakingTech);
                newPizza = new Pizza(pizzaArgs[1], newDough);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] ingredients = input.Split();

                grams = int.Parse(ingredients[2]);
                type = ingredients[1].ToLower();
                try
                {
                    Topping newTopping = new Topping(type, grams);
                    try
                    {
                        newPizza.AddTopping(newTopping);
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        return;
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return;
                }
            }
            Console.WriteLine($"{newPizza.Name} - {newPizza.Calories():f2} Calories.");
        }
    }
}
