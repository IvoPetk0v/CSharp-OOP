using Heroes.Models.Contracts;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int ClaymoreDmg = 20;

        public Claymore(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability == 0)
            {
                return 0;
            }
            this.Durability--;
            return ClaymoreDmg;
        }
    }
}
