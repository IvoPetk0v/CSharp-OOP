namespace Vehicles_Extension.Models
{
    using System;

    public class Car : Vehicles
    {
        private const double FuelConsumptAC = 0.9;

        public Car(double tankCapacity, double fuelQty, double fuelConsumpt) : base(tankCapacity, fuelQty, fuelConsumpt)
        {
        }

        public  override double FuelConsumptModifier => FuelConsumptAC;

     }
}
