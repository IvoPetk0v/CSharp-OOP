namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const decimal DefCoffeePrice = 3.50m;
        public const double DefCoffeeMills = 50;

        public Coffee(string name,double caffeine) : base(name,DefCoffeePrice,DefCoffeeMills)
        {
            this.CoffeeMilliliters = DefCoffeeMills;
            this.CoffeePrice = DefCoffeePrice;
            this.Caffeine = caffeine;
        }

        public double CoffeeMilliliters { get; private set; }
        public decimal CoffeePrice { get; private set; }
        public double Caffeine { get; set; }

    }
}
