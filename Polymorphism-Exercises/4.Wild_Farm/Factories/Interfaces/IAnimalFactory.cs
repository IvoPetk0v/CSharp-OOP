namespace Wild_Farm.Factories.Interfaces
{
    using Models.Animals;
    using System;

    public interface IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string thirdParam, string forthParam = null);
        
    }
}
