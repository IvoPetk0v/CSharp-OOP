using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void StartUp()
        {
            this.smartphone = new Smartphone("Nokia", 10);
            this.shop = new Shop(3);
        }

        [TestCase(-100)]
        [TestCase(-1)]
        public void CapacityCantBeNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(
                () => this.shop = new Shop(capacity),
                "Invalid capacity.");
        }

        [Test]
        public void CountShouldReturnCorrectlyNumberOfPhones()
        {
            this.shop.Add(smartphone);
            Assert.AreEqual(1, this.shop.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfAlreadyHaveSameModel()
        {
            this.shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(
                () => this.shop.Add(smartphone),
                $"The phone model {this.smartphone.ModelName} already exist.");
        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsFull()
        {
            this.shop = new Shop(1);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("OP", 30)),
                "The shop is full.");
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenThereIsNoSuchPhone()
        {
            this.shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(
                () => this.shop.Remove("NoModelName"),
                "The phone model NoModelName doesn't exist.");
        }

        [Test]
        public void RemoveShouldRemovePhoneWhenIsInShop()
        {
            this.shop.Add(smartphone);
            this.shop.Remove("Nokia");
            Assert.AreEqual(0, this.shop.Count);
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWhenThereIsNoSuchPhone()
        {
            this.shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(
                () => this.shop.TestPhone("NoModel", 10),
                $"The phone model NoModel doesn't exist.");
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWhenBatteryNotEnough()
        {
            this.shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(
                () => this.shop.TestPhone("Nokia", 100),
                $"The phone model {this.smartphone.ModelName} is low on batery.");
        }

        [Test]
        public void TestPhoneShouldDecreaseBatteryCorrectly()
        {
            this.shop.Add(smartphone);
            this.shop.TestPhone(this.smartphone.ModelName, 1);
            Assert.AreEqual(9, this.smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargingShouldThrowExceptionWhenThereIsNoSuchPhone()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.shop.ChargePhone(this.smartphone.ModelName),
                $"The phone model {this.smartphone.ModelName} doesn't exist.");
        }

        [Test]
        public void ChargingShouldReturnFullBattery()
        {
            this.shop.Add(smartphone);
            this.shop.TestPhone("Nokia",5);
            Assert.AreNotEqual(smartphone.MaximumBatteryCharge,smartphone.CurrentBateryCharge);
            this.shop.ChargePhone("Nokia");
            Assert.AreEqual(this.smartphone.MaximumBatteryCharge,this.smartphone.CurrentBateryCharge);
        }
    }
}