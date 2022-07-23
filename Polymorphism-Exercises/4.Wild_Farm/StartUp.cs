using System;

namespace Wild_Farm
{
    using Factories;
    using Factories.Interfaces;
    using Core;
    using Core.Interfaces;
  
    class StartUp
    {
        static void Main()
        {
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();
            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Start();
        }
    }
}
