namespace _1.Vehicles.Factories
{
    using System;
    using Models;

    public interface IVehicleFactory
    {
        public Vehicles CreateVehicle(string typeVehicle, double fuelQyt, double fuelConsumpt)
        {
            Vehicles vehicle;
            if (typeVehicle == "Car")
            {
                vehicle = new Car(fuelQyt, fuelConsumpt);
            }
            else if (typeVehicle == "Truck")
            {
                vehicle = new Truck(fuelQyt, fuelConsumpt);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type");
            }
            return vehicle;
        }
    }
}
