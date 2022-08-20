using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
        [SetUp]
        public void Start()
        {
            this.aquarium = new Aquarium("Aqua", 10);
            this.fish = new Fish("Nemo");
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropNameShouldNotBeEmptyOrNull(string name)
        {
            Assert.Throws<ArgumentNullException>(
                () => this.aquarium = new Aquarium(name, 10),
                nameof(name), "Invalid aquarium name!");

        }

        [Test]
        public void PropCountShouldReturnCorrectlyValue()
        {
            this.aquarium.Add(fish);
            Assert.AreEqual(1, this.aquarium.Count);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void PropCapacityShouldNotBeNegativeNumber(int capacity)
        {
            Assert.Throws<ArgumentException>(
                () => this.aquarium = new Aquarium("aqua", capacity),
                "Invalid aquarium capacity!");
        }

        [TestCase(0)]

        public void AddShouldThrowExceptionWhenCapacityIsReached(int capacity)
        {
            this.aquarium = new Aquarium("aqua", capacity);
            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(fish), "Aquarium is full!");
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.aquarium.Add(fish);
            this.aquarium.Add(fish);
            Assert.AreEqual(2, this.aquarium.Count);
        }

        [TestCase("noName")]
        [TestCase("")]
        public void RemoveShouldThrowExceptionWhenNoFish(string name)
        {
            this.aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(
                () => this.aquarium.RemoveFish(name),
                $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void RemoveShouldRemoveByName()
        {
            this.aquarium.Add(fish);
            this.aquarium.RemoveFish("Nemo");
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void SellFishShouldReturnFishByName()
        {
            //Arrange and Act
            this.aquarium.Add(fish);
            var requestedFish = this.aquarium.SellFish(this.fish.Name);
            //Assert
            Assert.AreSame(this.fish, requestedFish);
            Assert.IsFalse(requestedFish.Available,
                "When Fish is Sold it must be not Available anymore");
        }

        [TestCase("noName")]
        [TestCase("")]
        [TestCase("nemo")]
        public void SellFishShouldThrowExceptionIfNoFishWithThatName(string name)
        {
            this.aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(
                () => this.aquarium.SellFish(name),
                $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void ReportShouldReturnStringCorrectly()
        {
            this.aquarium.Add(fish);
            this.aquarium.Add(new Fish("Mone"));
            string actualResult = this.aquarium.Report();
            string expectedResult = $"Fish available at {this.aquarium.Name}: Nemo, Mone";
            Assert.AreEqual(expectedResult,actualResult);
            this.aquarium.RemoveFish("Mone");
            actualResult = this.aquarium.Report();
            expectedResult= $"Fish available at {this.aquarium.Name}: Nemo";
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
