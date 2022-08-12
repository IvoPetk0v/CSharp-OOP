using System;
using System.Reflection.Metadata;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Start()
        {
            this.warrior = new Warrior("Mich", 10, 50);
        }

        //Testing ctor 
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Mich", this.warrior.Name);
            Assert.AreEqual(10, this.warrior.Damage);
            Assert.AreEqual(50, this.warrior.HP);
        }

        //Testing Property setters` Validations
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyNameValidationShouldThrowExceptionWhenNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
                    new Warrior(name, 10, 50),
                "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void PropertyDamageValidationShouldThrowExceptionWhenNegativeOr0(int dmg)
        {
            Assert.Throws<ArgumentException>(() =>
                    new Warrior("Mich", dmg, 50),
                "Damage value should be positive!");
        }

        [Test]
        public void PropertyHPValidationShouldThrowExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() =>
                new Warrior("Mich", 10, -1),
                "HP should not be negative!");
        }

        //Testing Attack method
        [TestCase(30)]
        [TestCase(29)]
        public void WarriorShouldNotAttackWhenHPLessThanMinThresh(int hp)
        {
            var warrior = new Warrior("Weaky", 1, hp);
            Assert.Throws<InvalidOperationException>(() =>
                warrior.Attack(warrior),
                "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(30)]
        [TestCase(29)]
        public void WarriorShouldNotAttackWhenHPDefWarriorLessThanMinThresh(int hp)
        {
            Assert.Throws<InvalidOperationException>(() =>
                     this.warrior.Attack(new Warrior("Weaky", 1, hp)),
                 "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void WarriorShouldNotAttackWhenHPLessThanDefDamage()
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.warrior.Attack(new Warrior("GodsDamage", 51, 31)),
                "You are trying to attack too strong enemy");
        }


        [TestCase(10, 33, 40)]
        [TestCase(50, 33, 0)]
        public void WarriorShouldTakeDmgFromDefender(int dmg, int hp, int expectedHp)
        {
            var defender = new Warrior("Hitman", dmg, hp);
            warrior.Attack(defender);
            Assert.AreEqual(expectedHp, this.warrior.HP);

        }

        [TestCase(50, 0)]
        [TestCase(30, 20)]
        [TestCase(51, 0)]
        public void WarriorShouldDecreaseDefHpProperly(int dmg, int defHP)
        {
            var attacker = new Warrior("Hitman", dmg, 100);
            attacker.Attack(this.warrior);
            Assert.AreEqual(defHP, this.warrior.HP);
        }
    }
}