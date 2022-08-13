using System;
using System.Collections.Generic;
using System.Text;
using Heroes.Utilities.HeroExceptions;

namespace Heroes.Utilities
{
    public class HeroExceptionMessages:ArgumentException,IHeroExceptions
    {
        private readonly IHeroExceptions heroExc;
        public void HeroNameException()
        {
            throw new ArgumentException(this.heroExc.NameCantBeNullOrWhitespace());
        }

        public void HeroHealthException()
        {
            throw new ArgumentException(this.heroExc.HealthCantBeBelow0());
        }

        public void HeroArmorException()
        {
            throw new ArgumentException(this.heroExc.ArmourCantBeBelow0());
        }

        public void HeroNoWeaponException()
        {
            throw new ArgumentException(this.heroExc.WeaponCantBeNull());
        }
    }
}
