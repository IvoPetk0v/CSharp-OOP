using System;
using System.Security.Cryptography.X509Certificates;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void Start()
        {
            this.car = new Car("Mazda", "Rx8", 7.5, 80.50);
        }
        //Test the ctor
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string make = "Mazda", model = "Rx8";
            double fuelConsumption = 7.5;
            double fuelCapacity = 80.50;
            Assert.AreEqual(make, this.car.Make);
            Assert.AreEqual(model, this.car.Model);
            Assert.AreEqual(fuelCapacity, this.car.FuelCapacity);
            Assert.AreEqual(fuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(0, this.car.FuelAmount);
        }
        //Testing property setters` Validations
        [TestCase("")]
        [TestCase(null)]
        public void PropertyMakeShouldValidateCorrectly(string make)
        {
            Assert.Throws<ArgumentException>(() =>
              new Car(make, "Rx8", 7.5, 80.50),
                "Make cannot be null or empty!");
        }

        [TestCase("")]
        [TestCase(null)]
        public void PropertyModelShouldValidateCorrectly(string model)
        {
            Assert.Throws<ArgumentException>(() =>
                new Car("Mazda", model, 7.5, 80.50),
                "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void PropertyFuelConsumpShouldValidateCorrectly(double fuelConsump)
        {
            Assert.Throws<ArgumentException>(() =>
                    new Car("Mazda", "Rx8", fuelConsump, 80.50),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void PropertyFuelAmountShouldValidateCorrectly()
        {
            Assert.Throws<ArgumentException>(() =>
                    new Car("Mazda", "Rx8", 5.5, -1.1),
                "Fuel amount cannot be negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void PropertyFuelCapacityShouldValidateCorrectly(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                    new Car("Mazda", "Rx8", 5.5, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");
        }

        //Testing Refuel method
        [TestCase(-1.1)]
        [TestCase(0)]
        public void RefuelShouldThrowExceptionIfParamIsNegativeOr0(double fuel)
        {
            Assert.Throws<ArgumentException>(() =>
                this.car.Refuel(fuel), "Fuel amount cannot be zero or negative!");
        }

        [TestCase(500.1)]
        [TestCase(80.50)]
        public void RefuelShouldFillTankUpToFuelCapacity(double fuel)
        {
            //Arrange and Act
            this.car.Refuel(fuel);
            double actualFuelAmount = this.car.FuelAmount;
            double expectedFuelAmount = this.car.FuelCapacity;
            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "Refuel should go up to fuel capacity");
        }

        [Test]
        public void RefuelShouldRefillCorrectly()
        {
            this.car.Refuel(0.1);
            Assert.AreEqual(0.1, this.car.FuelAmount);
        }
        //Testing Drive method  
        [TestCase(100.1)]
        [TestCase(100)]
        public void DriveShouldThrowExceptionWhenHaveNoEnoughFuel(double distance)
        {
            this.car.Refuel(7.4);
            Assert.Throws<InvalidOperationException>(() =>
                    this.car.Drive(distance),
                "You don't have enough fuel to drive!");
        }

        [TestCase(7.5, 100, 0)]
        [TestCase(80.5, 100, 73.0)]
        public void DriveShouldDecreaseFuelAmountWhenRunTheDistance(double fuel, double distance, double expectedFuelAmount)
        {
            this.car.Refuel(fuel);
            this.car.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

    }
}