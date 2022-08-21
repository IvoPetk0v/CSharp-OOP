﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
        {
            get => this.models.ToList().AsReadOnly();
        }
        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.RaceName == name);
        }
    }
}
