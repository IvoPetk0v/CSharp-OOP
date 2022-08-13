using System;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Utilities.WeaponsExceptions;
using Utilities;

namespace Heroes.Models.Weapons
{
    using Utilities;

    public abstract class Weapon : WeaponExceptionMessages, IWeapon
    {
        internal WeaponExceptionMessages excMsg;

        private string name;
        private int durability;

        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    excMsg.WeaponNameException();
                }
                this.name = value;
            }
        }
        public int Durability
        {
            get => this.durability;
            protected set
            {
                if (value < 0)
                {
                    excMsg.WeaponDurabilityException();
                }
                this.durability = value;
            }
        }
        public abstract int DoDamage();
    }
}
