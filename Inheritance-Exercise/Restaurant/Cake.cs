namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DeffGrams = 250;
        private const double DeffCalories = 1000;
        private const decimal DeffPrice = 5m;
        public Cake(string name):base(name,DeffPrice,DeffGrams,DeffCalories)
        {

        }
    }
}
