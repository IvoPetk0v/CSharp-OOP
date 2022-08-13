using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        private  ICollection<Knight> knights = new List<Knight>();
        private ICollection<Barbarian> barbarians = new List<Barbarian>();

        public string Fight(ICollection<IHero> players)
        {
            this.knights = players.OfType<Knight>().Where(k=>k.IsAlive==true).ToList();
               
            this.barbarians = players.OfType<Barbarian>().Where(b => b.IsAlive==true).ToList();
            string result;
            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (var barb in barbarians)
                        {
                            if (barb.IsAlive)
                            {
                                barb.TakeDamage(knight.Weapon.DoDamage());
                            }

                        }
                    }
                }

                foreach (var barb in barbarians)
                {
                    if (barb.IsAlive)
                    {
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barb.Weapon.DoDamage());
                            }
                        }
                    }
                }
            }

            if (knights.Any(k => k.IsAlive))
            {
                result =
                    $"The knights took {knights.Count(k => k.IsAlive == false)} casualties but won the battle.";
                return result;
            }
            result = $"The barbarians took {barbarians.Count(barb => barb.IsAlive == false)} casualties but won the battle.";
            return result;


        }
    }
}
