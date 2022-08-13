using System;
using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;


        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
            this.isAlive = true;
            this.weapon = null;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
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
                    throw new ArgumentException("Hero health cannot be below 0.");
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
                    throw new ArgumentException("Hero armour cannot be below 0.");
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
                    throw new ArgumentException("Weapon cannot be null.");
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
                if (this.health <= 0)
                {
                    this.health = 0;
                    this.isAlive = false;
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

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name}{Environment.NewLine}" +
                   $"--Health: {this.Health}{Environment.NewLine}" +
                   $"--Armour: {this.Armour}{Environment.NewLine}" +
                   $"--Weapon: {(this.Weapon == null ? "Unarmed" : this.Weapon.Name)}".ToString();
        }
    }
}
