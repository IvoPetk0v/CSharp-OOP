using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly HashSet<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new HashSet<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models;

        public void Add(IDecoration model)
        {
           this.models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(m => m.GetType().Name == type);
        }
    }
}
