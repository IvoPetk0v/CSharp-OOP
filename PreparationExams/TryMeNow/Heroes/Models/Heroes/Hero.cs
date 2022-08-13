using System;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using Heroes.Utilities;
using Utilities;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : HeroExceptionMessages, IHero
    {
        private readonly HeroExceptionMessages exc;
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;


        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.exc.HeroNameException();
                }

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    this.exc.HeroHealthException();
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    this.exc.HeroArmorException();
                }
                this.armour = value;
            }
        }

        public bool IsAlive
        {
            get => this.isAlive;
            private set
            {
                if (this.health > 0)
                {
                    this.isAlive = true;

                }
                this.isAlive = false;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            protected set
            {
                if (value == null)
                {
                    this.exc.HeroNoWeaponException();
                }
                this.weapon = value;
            }
        }
        public void TakeDamage(int points)
        {
            points -= this.armour;
            if (points > 0)
            {
                this.armour = 0;
                this.health -= points;
                if (!this.IsAlive)
                {
                    this.health = 0;
                }
                return;
            }
            this.armour = Math.Abs(points);
            return;
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }
    }
}
