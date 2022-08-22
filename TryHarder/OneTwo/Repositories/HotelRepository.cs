using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
   public  class HotelRepository:IRepository<IHotel>
   {
       private readonly List<IHotel> models;

       public HotelRepository()
       {
           this.models = new List<IHotel>();
       }

        public void AddNew(IHotel model)
        {
           this.models.Add(model);
        }

        public IHotel Select(string criteria)
        {
            return this.models.FirstOrDefault(h => h.FullName == criteria);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.models.AsReadOnly();
        }
    }
}
