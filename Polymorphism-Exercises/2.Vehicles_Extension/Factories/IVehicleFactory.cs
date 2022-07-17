namespace Vehicles_Extension.Factories

{
    using System;
    using Vehicles_Extension.Models;

    public interface IVehicleFactory
    {
        public Vehicles CreateVehicle(string typeVehicle,double fuelQyt, double fuelConsumpt, double tankCapacity)
        {
            Vehicles vehicle;

            if (typeVehicle == "Car")
            {
                vehicle = new Car(tankCapacity, fuelQyt, fuelConsumpt);
            }
            else if (typeVehicle == "Truck")
            {
                vehicle = new Truck(tankCapacity, fuelQyt, fuelConsumpt);
            }
            else if (typeVehicle == "Bus")
            {
                vehicle = new Bus(tankCapacity, fuelQyt, fuelConsumpt);
               
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type");
            }
            return vehicle;
        }
    }
}
