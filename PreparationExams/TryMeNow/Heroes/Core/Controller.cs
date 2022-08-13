using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IWeapon> weapons;
        private IRepository<IHero> heroes;

        public Controller()
        {
            this.weapons = new WeaponRepository();
            this.heroes = new HeroRepository();
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            throw new NotImplementedException();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            throw new NotImplementedException();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }

        public string HeroReport()
        {
            throw new NotImplementedException();
        }
    }
}
