using System;
using System.Collections.Generic;
using System.Threading;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void Start()
        {
            db = new Database();
        }

        // Valid functionality of ctor
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddLessThan17Elements(int[] elementsToAdd)
        {
            //Arrange
            Database testDb = new Database(elementsToAdd);

            //Act
            int[] expectedData = elementsToAdd;
            int[] actualData = testDb.Fetch();
            int expectedCount = expectedData.Length;
            int actualCount = testDb.Count;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData,
                "Database constructor should initialize data fields correctly");
            Assert.AreEqual(expectedCount, actualCount,
                "Database constructor should set correctly value for count field");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void ConstructorShouldNotAllowOverExceedMaxCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);

            },
                "Array's capacity must be exactly 16 integers!");
        }

        //Testing Count functionality
        [Test]
        public void CountShouldReturnActualCount()
        {
            //Arrange
            int[] elementsToAdd = new int[] { 1, 2, 3, 4 };
            Database testDb = new Database(elementsToAdd);

            //Act
            int expectedCount = elementsToAdd.Length;
            int actualCount = testDb.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnZeroWhenNoElementsInDatabase()
        {
            //Arrange and Act
            int expectedCount = 0;
            int actualCount = this.db.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount, "Count did not work proper when db is empty");
        }

        //Testing Add function 
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan17Elements(int[] elementsToAdd)
        {
            //Arrange and Act
            foreach (int element in elementsToAdd)
            {
                this.db.Add(element);
            }

            int expectedCount = elementsToAdd.Length;
            int actualCount = db.Count;

            int[] expectedData = elementsToAdd;
            int[] actualData = this.db.Fetch();

            //Assert
            Assert.AreEqual(expectedCount, actualCount,
                "Count should increment with every added element");
            CollectionAssert.AreEqual(expectedData, actualData,
                "Add functionality should add element to the database");

        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            //Arrange and Act
            for (int i = 1; i <= 16; i++)
            {
                db.Add(i);
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                this.db.Add(17), "Array's capacity must be exactly 16 integers!");
        }

        //Testing Remove function 
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveSingleElementSuccessfully(int[] startElements)
        {
            //Arrange and Act
            foreach (int element in startElements)
            {
                this.db.Add(element);
            }
            this.db.Remove();
            List<int> elementList = new List<int>(startElements);
            elementList.RemoveAt(elementList.Count - 1);
            int[] expectedData = elementList.ToArray();
            int[] actualData = this.db.Fetch();

            int expectedCount = expectedData.Length;
            int actualCount = this.db.Count;
            //Assert
            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should remove element in database");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove should decrement count of database");
        }

        [Test]
        public void RemoveShouldThrowErrorWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this.db.Remove(), "The collection is empty!");
        }

        //Testing Fetch function
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyOfArrayWithElements(int[] initData)
        {
            //Arrange and Act
            foreach (int element in initData)
            {
                this.db.Add(element);
            }
            int[] expectedData = initData;
            int[] actualData = this.db.Fetch();

            //Assert
            Assert.AreEqual(expectedData, actualData, "Fetch should return copy of existing data.");
        }

    }
}
