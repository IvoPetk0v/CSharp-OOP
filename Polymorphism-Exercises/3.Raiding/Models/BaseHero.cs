
namespace Raiding.Models
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }
        public int Power
        {
            get => this.power;
            private set
            {
                this.power = value;
            }
        }

        public abstract string CastAbility();

    }
}
