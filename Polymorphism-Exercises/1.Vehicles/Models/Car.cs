namespace _1.Vehicles.Models
{
    public class Car : Vehicles
    {
        private const double FuelConsumptAC = 0.9;

        public Car(double fuelQty, double fuelConsumpt) : base(fuelQty, fuelConsumpt)
        {
        }

        protected override double FuelConsumptModifier => FuelConsumptAC;

        public override string Drive(double distance)
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

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
