using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models = new Collection<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models => this.models.ToList();

        public void Add(IWeapon model)
        {
            this.models.Add(model);
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
