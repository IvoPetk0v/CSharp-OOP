using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Repositories
{
    using Contracts;
    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models = new Collection<IHero>();


        public IReadOnlyCollection<IHero> Models => this.models.ToList();

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public bool Remove(IHero model)
        {
            return this.models.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return this.models.FirstOrDefault(m=>m.Name==name);
        }
    }
}
