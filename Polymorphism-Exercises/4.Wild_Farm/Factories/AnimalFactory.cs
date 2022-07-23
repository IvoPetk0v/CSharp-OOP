
namespace Wild_Farm.Factories
{
    using System;

    using Interfaces;
    using Models.Animals;

    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string thirdParam, string forthParam = null)
        {
            Animal animal;
            if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, thirdParam);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, thirdParam, forthParam);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, thirdParam);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, thirdParam, forthParam);
            }
            else
            {
                throw new Exception("wrong type");
            }
            return animal;
        }
    }
}

