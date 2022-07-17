namespace Vehicles_Extension.Models
{
    using System;
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicles(double tankCapacity, double fuelQty, double fuelConsumpt)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumpt;
            this.FuelQuantity = fuelQty;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (this.TankCapacity < value)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set
            {
                this.fuelConsumption = value + this.FuelConsumptModifier;
            }
        }
        public double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                this.tankCapacity = value;
            }
        }
        public virtual  double FuelConsumptModifier { get; }
        public virtual string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }
        public virtual void Refuel(double liters)
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
                    this.FuelQuantity += liters;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
         }
        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
