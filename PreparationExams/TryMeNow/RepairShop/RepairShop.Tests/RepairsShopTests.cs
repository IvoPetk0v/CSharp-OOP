using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage garage;
            private Car car;
            [SetUp]
            public void Start()
            {
                this.garage = new Garage("TOP", 3);
                this.car = new Car("Mazda", 2);
            }
            [Test]
            public void ConstructorShouldWorkProperly()
            {
                this.garage = new Garage("Top", 3);
                Assert.AreEqual("Top", garage.Name);
                Assert.AreEqual(3, garage.MechanicsAvailable);
                Assert.AreEqual(0, this.garage.CarsInGarage);
            }
            [TestCase("")]
            [TestCase(null)]
            public void PropertyNameShouldThrowExceptionWhenNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                    this.garage = new Garage(name, 3),
                    "Invalid garage name.");
            }

            [TestCase(0)]
            [TestCase(-1)]
            public void PropertyMechanicsAvailableShouldThrowExceptionWhenNegativeOr0(int mechAvailable)
            {
                Assert.Throws<ArgumentException>(() =>
                    this.garage = new Garage("LG", mechAvailable),
                    "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CarsInGarageShouldReturnCorrectlyCountOfCars()
            {
                this.garage.AddCar(car);
                Assert.AreEqual(1, this.garage.CarsInGarage);
            }

            [Test]
            public void AddCarShouldThrowExceptionIfNoMoreMechAvailable()
            {
                garage.AddCar(car);
                garage.AddCar(car);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() =>
                    garage.AddCar(car),
                    "No mechanic available.");
            }

            [TestCase(3)]
            [TestCase(2)]
            public void AddCarShouldAddCarIfThereAreEnoughMechAvailable(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    this.garage.AddCar(car);
                }
                Assert.AreEqual(n,this.garage.CarsInGarage);
            }

        }
    }
}