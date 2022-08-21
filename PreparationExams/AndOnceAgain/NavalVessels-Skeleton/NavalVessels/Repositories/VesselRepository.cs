using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            this.models = new HashSet<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models
        {
            get => this.models.ToImmutableHashSet();
        }
        public void Add(IVessel model)
        {
            this.models.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return this.models.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return this.models.FirstOrDefault(v => v.Name == name);
        }
    }
}
