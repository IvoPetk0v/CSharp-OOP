namespace Vehicles_Extension
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
            string[] busData = Console.ReadLine().Split();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicles car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            Vehicles truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            Vehicles bus = vehicleFactory.CreateVehicle(busData[0], double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));
            IEngine engine = new Engine(car, truck,bus);
            engine.Start();
        }
    }
}
