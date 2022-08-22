using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight = 0;
        private int bedCapacity;

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }
        public int BedCapacity
        {
            get => this.bedCapacity;
            private set
            {
                this.bedCapacity = value;
            }

        }
        public double PricePerNight
        {
            get => this.pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                this.pricePerNight = value;
            }
        }
        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
