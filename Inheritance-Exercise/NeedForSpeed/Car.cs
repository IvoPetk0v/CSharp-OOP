
namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3.00;

        public Car(int horsePower,double fuel):base(horsePower,fuel)
        {
            this.FuelConsumption = DefaultFuelConsumption;
        }
    }
}
