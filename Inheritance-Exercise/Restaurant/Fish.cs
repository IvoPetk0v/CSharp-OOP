namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double DefGrams = 22;
        public Fish(string name, decimal price) : base(name, price, DefGrams)
        {
            this.Grams = DefGrams;
        }
    }
}
