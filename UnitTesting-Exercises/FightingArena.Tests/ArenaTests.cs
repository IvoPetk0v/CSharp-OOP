using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Start()
        {
            this.arena = new Arena();
        }
        //Testing Ctor
        [Test]
        public void ConstructorShouldInitializeEmptyWarriorList()
        {
            Assert.AreEqual(new List<Warrior>(), this.arena.Warriors.ToList());
            Assert.AreEqual(0,this.arena.Count);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorAlreadyEnrolled()
        {
            //Arrange and Act
            var warrior = new Warrior("Artur", 5, 35);
            this.arena.Enroll(warrior);
            //Assert
            Assert.AreEqual(warrior,this.arena.Warriors.First());
            Assert.AreEqual(1,this.arena.Count);
            Assert.Throws<InvalidOperationException>(() =>
                this.arena.Enroll(warrior),
                "Warrior is already enrolled for the fights!");
        }

        [TestCase("Hitman", "BussyToCome")]
        [TestCase("BussyToCome", "Defender")]
        public void FightingShouldThrowExceptionIfOneOfWarriorsIsNotEnrolled(string attackerName,string defenderName)
        {
            //Arrange
            var attacker = new Warrior("Hitman", 1, 100);
            var defender = new Warrior("Defender", 1, 100);
            //Act
            arena.Enroll(attacker);
            arena.Enroll(defender);
            //Assert
            Assert.Throws<InvalidOperationException>(() => 
                arena.Fight(attackerName,defenderName), "There is no fighter with name BussyToCome enrolled for the fights!");
        }

        [Test]
        public void FightShouldCallAttackMethodIfTwoNamesAreEnrolled()
        {
            //Arrange
            var attacker = new Warrior("Hitman", 1, 100);
            var defender = new Warrior("Defender", 1, 100);
            //Act
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight("Hitman","Defender");
            Assert.AreEqual(99,attacker.HP);
            Assert.AreEqual(99,defender.HP);
        }

    }
}
