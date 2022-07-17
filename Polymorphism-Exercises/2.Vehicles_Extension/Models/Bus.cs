
namespace Vehicles_Extension.Models
{
    class Bus : Vehicles
    {
        private const double FuelConsumptAC = 1.4;

        public Bus(double tankCapacity, double fuelQty, double fuelConsumpt) : base(tankCapacity, fuelQty, fuelConsumpt)
        {
        }

        public override double FuelConsumptModifier =>FuelConsumptAC;

        public string DriveEmpty(double distance)
        {
            double neededFuel = distance * (this.FuelConsumption-FuelConsumptAC);
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
    }
}
