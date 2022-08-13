using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
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

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(
                    $"The hero {name} already exists.");
            }
            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };
            this.heroes.Add(hero);
            string heroAlias = type == nameof(Knight)
                ? $"Sir {hero.Name}"
                : $"{nameof(Barbarian)} {hero.Name}";
            return $"Successfully added {heroAlias} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(
                    $"The weapon { name } already exists.");
            }
            IWeapon weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _ => throw new InvalidOperationException("Invalid weapon type.")
            };
            this.weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            var weapon = weapons.FindByName(weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException(
                    $"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException(
                    $"Weapon { weaponName } does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(
                    $"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            string weaponType = weapon.GetType().Name.ToLower();
            return $"Hero {heroName} can participate in battle using a {weaponType}.";
        }

        public string StartBattle()
        {
            var map = new Map();
            var heroesForBattle = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(heroesForBattle);
        }

        public string HeroReport()
        {
            var sortedListOfHeroes = this.heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);
            StringBuilder sb = new StringBuilder();
            foreach (var hero in sortedListOfHeroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
