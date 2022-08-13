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
                Assert.AreEqual(n, this.garage.CarsInGarage);
            }

            [TestCase("Fail")]
            [TestCase("NeverSeen")]
            public void FixCarShouldThrowExceptionWhenInputModelIsNotFound(string name)
            {
                this.garage.AddCar(car);
                this.garage.AddCar(new Car("Opel", 3));
                Assert.Throws<InvalidOperationException>(() =>
                    garage.FixCar(name),
                    $"The car {name} doesn't exist.");
            }

            [Test]
            public void FixCarShouldResetTo0NumberOfIssuesCarPropIfModelIsFound()
            {
                this.garage.AddCar(car);
                this.garage.FixCar(car.CarModel);
                Assert.AreEqual(0, this.car.NumberOfIssues);
            }

            [Test]
            public void RemoveFixedCarsShouldThrowExceptionIfThereIsNoFixedCars()
            {
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() =>
                    garage.RemoveFixedCar(),
                    "No fixed cars available.");
            }
            [Test]
            public void RemoveFixedCarsShouldRemoveAllFixedCars()
            {
                garage.AddCar(car);
                garage.AddCar(new Car("Opel",2));
                garage.FixCar("Mazda");
                garage.FixCar("Opel");
                garage.RemoveFixedCar();
                Assert.AreEqual(0,garage.CarsInGarage);
            }

            [Test]
            public void ReportShouldReturnStringTheListOfNotFixedCarInGarage()
            {
                garage.AddCar(car);
                garage.AddCar(new Car("BMW",30));
                garage.AddCar(new Car("Opel",2));
                garage.FixCar("Opel");
                Assert.AreEqual("There are 2 which are not fixed: Mazda, BMW.",garage.Report());

            }
        }
    }
}