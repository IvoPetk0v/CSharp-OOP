using System;

namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person person;

        [SetUp]
        public void Start()
        {
            this.db = new Database();
            this.person = new Person(123, "Name");
        }
        //Testing the ctor

        [Test]
        public void DatabaseConstructorShouldInitializeCorrectly()
        {
            //Arrange and Act
            Person expectedPerson = this.person;
            this.db = new Database(expectedPerson);
            Person actualPerson = db.FindById(123);
            //Assert
            Assert.AreEqual(expectedPerson, actualPerson, "Person should be add during initialization of the instance by the CTOR");
        }
        [Test]
        public void ConstructorShouldNotAllowOverExceedMaxCount()
        {
             Assert.Throws<ArgumentException>(() =>
                {
                    var testDb = new Database(new Person[17]);

                },
                "Provided data length should be in range [0..16]!");
        }

        //Testing Adding functionality 
        [Test]
        public void AddShouldAddPersonToDatabase()
        {
            //Arrange and Act 
            this.db.Add(this.person);
            int expectedCount = 1;
            int actualCount = db.Count;
            Person expectedPerson = this.person;
            Person actualPerson = db.FindByUsername(this.person.UserName);
            //Assert
            Assert.AreEqual(expectedCount, actualCount, "Add method  should increase count of the Database");
            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void AddShouldAddUpTo16Persons()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "Name" + i));
            }

            int actualCount = db.Count;
            int expectedCount = 16;
            Assert.AreEqual(expectedCount,actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenPersonAlreadyExistWithSameName()
        {
            db.Add(this.person);
            Assert.Throws<InvalidOperationException>(() =>
                db.Add((new Person(888,"Name"))),
                "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenPersonAlreadyExistWithSameId()
        {
            db.Add(this.person);
            Assert.Throws<InvalidOperationException>(() =>
                db.Add((new Person(123,"SameID"))),
                "There is already user with this Id!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenDbCountIsMoreThan16()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "Name" + i));
            }
            Assert.Throws<InvalidOperationException>(() =>
                db.Add((this.person)),
                "Array's capacity must be exactly 16 integers!");
        }
        //Testing Remove functionality
        [Test]
        public void RemoveShouldRemoveLastElementFromDb()
        {
            db.Add(this.person);
            db.Add(new Person(666,"PersonForRemove"));
            db.Remove();
            int expectedCount = 1;
            int actualCount = db.Count;
            Person actualPerson = db.FindById(this.person.Id);
            Assert.AreEqual(expectedCount,actualCount,"Remove should decrement Database count");
            Assert.AreEqual(this.person,actualPerson,"Remove should remove the last element");
            
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
                db.Remove());
        }
        //Testing FindingByName
        [Test]
        public void FindByUsernameShouldReturnPersonWithThatName()
        {
            db.Add(this.person);
            Person actualPerson = db.FindByUsername(this.person.UserName);
            Assert.AreEqual(this.person,actualPerson);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenParamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                db.FindByUsername(null),
                "Username parameter is null!");

        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfNoPersonWithThatName()
        {
            db.Add(this.person);
            Assert.Throws<InvalidOperationException>(() =>
                    db.FindByUsername("NoSuchPerson"),
                "No user is present by this username!");
        }

        [Test]
        public void FindByUsernameShouldBeCaseSensitive()
        {
            db.Add(this.person);
            Assert.Throws<InvalidOperationException>(() =>
                    db.FindByUsername(this.person.UserName.ToLower()),
                "No user is present by this username!");
        }
        //Testing FindById functionality
        [Test]
        public void FindByIdShouldReturnPersonWithThatId()
        {
            db.Add(this.person);
            Person actualPerson = db.FindById(this.person.Id);
            Assert.AreEqual(this.person,actualPerson);
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfNoSuchPersonWithThatId()
        {
            Assert.Throws<InvalidOperationException>(() =>
                db.FindById(0000), "No user is present by this ID!");
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsNegative()
        {
            db.Add(this.person);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                db.FindById(-1), "Id should be a positive number!");
        }
    }
}