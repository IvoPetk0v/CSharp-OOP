
namespace Wild_Farm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.Weight} {this.LivingRegion}";
        }
    }

}
