namespace _1.Vehicles.Models
{
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicles(double fuelQty, double fuelConsumpt)
        {
            this.FuelConsumption = fuelConsumpt;
            this.FuelQuantity = fuelQty;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get => this.fuelConsumption;
            private set
            {
                this.fuelConsumption = value + this.FuelConsumptModifier;
            }
        }
        protected virtual double FuelConsumptModifier { get; }
        public abstract string Drive(double distance);
        public abstract void Refuel(double liters);
        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
