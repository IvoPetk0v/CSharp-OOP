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
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public bool Remove(IHero model)
        {
            return this.heroes.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(m=>m.Name==name);
        }
    }
}
