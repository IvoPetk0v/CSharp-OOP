using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities.HeroExceptions
{
    public interface IHeroExceptions
    {
        public string NameCantBeNullOrWhitespace()
        {
            return "Hero name cannot be null or empty.";
        }

        public string HealthCantBeBelow0()
        {
            return "Hero health cannot be below 0.";
        }

        public string ArmourCantBeBelow0()
        {
            return "Hero armour cannot be below 0.";
        }

        public string WeaponCantBeNull()
        {
            return "Weapon cannot be null.";
        }
    }
}
