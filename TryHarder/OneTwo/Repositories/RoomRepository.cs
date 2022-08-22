using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly  List<IRoom> models;

        public RoomRepository()
        {
            this.models = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.models.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return this.models.First(r => r.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this.models.AsReadOnly();
        }
    }
}
