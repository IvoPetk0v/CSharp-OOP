using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) == null)
            {
                this.hotels.AddNew(new Hotel(hotelName, category));
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }

            return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Count > 0 && hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName) != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }
            else if (roomTypeName is nameof(DoubleBed))
            {
                hotel.Rooms.AddNew(new DoubleBed());
                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }
            else if (roomTypeName is nameof(Studio))
            {
                hotel.Rooms.AddNew(new Studio());
                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }
            else if (roomTypeName is nameof(Apartment))
            {
                hotel.Rooms.AddNew(new Apartment());
                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName is nameof(DoubleBed))
            {
                if (hotel.Rooms.All().Count > 0 && hotel.Rooms.All().FirstOrDefault(r=>r.GetType().Name==roomTypeName) == null)
                {
                    return OutputMessages.RoomTypeNotCreated;
                }

                if (hotel.Rooms.Select(roomTypeName).PricePerNight != 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
                }
                hotel.Rooms.Select(roomTypeName).SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            }
            else if (roomTypeName is nameof(Studio))
            {
                if (hotel.Rooms.All().Count > 0 && hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName) == null)
                {
                    return OutputMessages.RoomTypeNotCreated;
                }

                if (hotel.Rooms.Select(roomTypeName).PricePerNight != 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
                }
                hotel.Rooms.Select(roomTypeName).SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            }
            else if (roomTypeName is nameof(Apartment))
            {
                if (hotel.Rooms.All().Count > 0 && hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName) == null)
                {
                    return OutputMessages.RoomTypeNotCreated;
                }

                if (hotel.Rooms.Select(roomTypeName).PricePerNight != 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
                }
                hotel.Rooms.Select(roomTypeName).SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().FirstOrDefault(h => h.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var checkHotelForBook = this.hotels.All().OrderBy(h => h.FullName).Where(h => h.Category == category);

            foreach (var hotel in checkHotelForBook)
            {
                var checkRoomsForBook = hotel.Rooms.All().Where(r => r.PricePerNight > 0).OrderBy(r => r.BedCapacity);
                foreach (var room in checkRoomsForBook)
                {
                    if (room.BedCapacity >= adults + children)
                    {
                        int bookingNum = hotel.Bookings.All().Count + 1;
                        hotel.Bookings.AddNew(new Booking(room, duration, adults, children, bookingNum));
                        return string.Format(OutputMessages.BookingSuccessful, bookingNum, hotel.FullName);
                    }
                }

            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();
            var hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var hotelBookings = hotel.Bookings.All();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();
            if (hotelBookings.Count == 0)
            {

                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotelBookings)
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }


            return sb.ToString().TrimEnd();
        }
    }
}
