using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
   public class BookingRepository:IRepository<IBooking>
   {
       private List<IBooking> models;

       public BookingRepository()
       {
           this.models = new List<IBooking>();
       }
        public void AddNew(IBooking model)
        {
           this.models.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return this.models.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria));
        }

        public IReadOnlyCollection<IBooking> All()
        {
          return  this.models.AsReadOnly();
        }
    }
}
