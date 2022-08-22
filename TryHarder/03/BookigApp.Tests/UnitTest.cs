using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        private Room room;
        private Booking booking;
        [SetUp]
        public void Setup()
        {
            this.hotel = new Hotel("Motel", 1);
            this.room = new Room(2, 50);
           
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RoomBedCapacityShouldBeMoreThan0(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() => this.room = new Room(bedCapacity, 50));
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void RoomPricePerNightShouldBeMoreThan0(int price)
        {
            Assert.Throws<ArgumentException>(() => this.room = new Room(1, price));
        }

        [TestCase(" ")]
        [TestCase(null)]
        public void NameShouldThrowExceptionWhenNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.hotel = new Hotel(name, 3));
        }

        [TestCase(0)]
        [TestCase(6)]
        public void CategoryShouldBeBetween1And5(int category)
        {
            Assert.Throws<ArgumentException>(() => this.hotel = new Hotel("Motel", category));
        }

        [Test]
        public void AddRoomShouldWorkProperly()
        {
            this.hotel.AddRoom(room);
            Assert.AreEqual(1, this.hotel.Rooms.Count);
        }

        [Test]
        public void BookingRoomShouldThrowExceptionIfNoAdult()
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(0, 3, 4, 40));
        }
        [Test]
        public void BookingRoomShouldThrowExceptionIfChildsNegative()
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(1, -1, 4, 40));
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void BookingRoomShouldThrowExceptionIfDurationIsLessThan1(int resDuration)
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(1, 0, resDuration, 40));
        }

        [Test]
        public void BookingRoomShouldBookRoomWithProperBedCapacity()
        {
            this.hotel.AddRoom(new Room(2, 10));
            this.hotel.AddRoom(new Room(3, 10));
            this.hotel.BookRoom(1,1,3,60);
            Assert.AreEqual(2,this.hotel.Bookings.Count);
            Assert.AreEqual(60,this.hotel.Turnover);

        }
    }
}