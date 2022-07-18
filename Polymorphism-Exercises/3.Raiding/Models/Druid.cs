namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name) : base(name, DruidPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
