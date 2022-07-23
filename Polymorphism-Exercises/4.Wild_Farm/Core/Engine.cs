namespace Wild_Farm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories.Interfaces;
    using Interfaces;
    using Models.Animals;
    using Wild_Farm.Models.Foods;

    public class Engine : IEngine
    {
        private IAnimalFactory animalFactory;
        private IFoodFactory foodFactory;
        private ICollection<Animal> animalsList;
        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.AnimalsList = new List<Animal>();
        }
        protected List<Animal> AnimalsList { get => this.animalsList.ToList(); set => animalsList = value; }

        public void Start()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalArgs = input.Split();
                string[] foodArgs = Console.ReadLine().Split();
                try
                {
                    Animal animal = CreateAnimal(animalArgs);
                    animalsList.Add(animal);
                    Food food = foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in animalsList)
            {
                Console.WriteLine(animal);
            }
        }
        private Animal CreateAnimal(string[] animalArgs)
        {
            Animal animal;
            if (animalArgs.Length == 5)
            {
                animal = animalFactory
                              .CreateAnimal(animalArgs[0], animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
               
            }
            else if (animalArgs.Length == 4)
            {
                animal = animalFactory.CreateAnimal(animalArgs[0], animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
               
            }
            else
            {
                throw new ArgumentException("wrong animal params");
            }
            return animal;
        }
    }
}
