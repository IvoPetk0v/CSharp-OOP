using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models => this.models.AsReadOnly();

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public void Add(IWeapon model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
       
        }

        public bool Remove(IWeapon model)
        {
            return this.models.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(w => w.Name == name);
        }
    }
}
