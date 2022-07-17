namespace _1.Vehicles
{
    using System;
    using Factories;
    using Models;
    using Core;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicles car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicles truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));
            IEngine engine = new Engine(car,truck);
            engine.Start();
        }
    }
}
