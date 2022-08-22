using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel

    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Bookings = new BookingRepository();
            this.Rooms = new RoomRepository();
        }
        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                this.fullName = value;
            }
        }
        public int Category
        {
            get => this.category;
            private set
            {
                if (value<1 || value>5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                this.category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double result = 0;
                foreach (var booking in this.Bookings.All())
                {
                    result +=booking.ResidenceDuration *booking.Room.PricePerNight;
                }

                return result;
            }
        }

        public IRepository<IRoom> Rooms { get;  set; }
        public IRepository<IBooking> Bookings { get;  set; }
    }
}
