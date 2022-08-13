namespace Utilities
{
    using System;

    using Heroes.Utilities.HeroExceptions;
    using Heroes.Utilities.WeaponsExceptions;

    public abstract class WeaponExceptionMessages : ArgumentException, IWeaponExceptions, IHeroExceptions
    {
        private IWeaponExceptions weaponExc;
      

        public void WeaponNameException()
        {
            throw new ArgumentException(this.weaponExc.NameCantBeNullOrWhitespace());
        }

        public void WeaponDurabilityException()
        {
            throw new ArgumentException(this.weaponExc.DurabilityCantBeBelow0());
        }

       
    }
}