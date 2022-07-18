
namespace Raiding.Factories
{
    using System;
    using Models;

    public interface IFactory
    {
        public BaseHero CreateHero(string name,string type) 
        {
            BaseHero hero;
            if (type== "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type=="Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type== "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new Exception("Invalid hero!");
            }
            return hero;
        }
    }
}
