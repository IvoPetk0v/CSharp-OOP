using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;

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
        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();

        public void Add(IHero model)
        {
            if (!heroes.Contains(model))
            {
                this.heroes.Add(model);
            }
            
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
