
namespace NeedForSpeed
{
    public class Vehicle
    {
       private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.FuelConsumption = DefaultFuelConsumption;
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }
        public virtual double FuelConsumption { get;  set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
