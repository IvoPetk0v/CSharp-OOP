using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int BedCapacityApartment = 6;
        public Apartment() : base(BedCapacityApartment)
        {
        }
    }
}
