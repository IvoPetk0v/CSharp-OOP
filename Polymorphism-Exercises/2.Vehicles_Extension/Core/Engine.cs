namespace Vehicles_Extension.Core
{
    using System;
    using Models;

    public class Engine : IEngine
    {
        private Vehicles car;
        private Vehicles truck;
        private Vehicles bus;
        public Engine(Vehicles car, Vehicles truck, Vehicles bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double cmdParam = double.Parse(cmdArgs[2]);
                if (cmdType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.car.Drive(cmdParam));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(cmdParam));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(this.bus.Drive(cmdParam));
                    }
                }
                else if (cmdType == "Refuel")
                {


                    if (vehicleType == "Car")
                    {
                        this.car.Refuel(cmdParam);
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.truck.Refuel(cmdParam);
                    }
                    else if (vehicleType == "Bus")
                    {
                        this.bus.Refuel(cmdParam);
                    }


                }
                else if (cmdType == "DriveEmpty")
                {
                    this.bus.FuelConsumption -= 2*this.bus.FuelConsumptModifier;
                    Console.WriteLine(this.bus.Drive(cmdParam));
                    this.bus.FuelConsumption = this.bus.FuelConsumption;
                }
            }
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}
