using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles_Extension.Models
{
    public class Truck : Vehicles
    {
        private const double FuelConsumptAC = 1.6;
        private const double RefuelCoefficent = 0.95;

        public Truck(double tankCapacity, double fuelQty, double fuelConsumpt) : base(tankCapacity, fuelQty, fuelConsumpt)
        {
        }
        public override void Refuel(double liters)
        {
            try
            {
                if (liters <= 0)
                {
                    throw new Exception("Fuel must be a positive number");
                }
                if (this.FuelQuantity + liters > this.TankCapacity)
                {
                    throw new Exception($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += liters * RefuelCoefficent;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public override double FuelConsumptModifier => FuelConsumptAC;

    }
}
