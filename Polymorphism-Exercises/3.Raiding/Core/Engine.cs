
namespace Raiding.Core
{
    using System;
    using Raiding.Factories;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private List<BaseHero> raidGroup = new List<BaseHero>();

        public void Start(int n, IFactory heroFactory)
        {
            
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string name = Console.ReadLine();
                    string heroType = Console.ReadLine();
                    BaseHero hero= heroFactory.CreateHero(name, heroType);
                    raidGroup.Add(hero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                    continue;
                }
               
            }
            long bossPower = long.Parse(Console.ReadLine());
            if (raidGroup.Count>0)
            {
                long raidGroupPower = 0;
                foreach (var hero in raidGroup)
                {
                    Console.WriteLine(hero.CastAbility());
                    raidGroupPower += hero.Power;
                }
              
                if (bossPower >raidGroupPower)
                {
                    Console.WriteLine("Defeat...");
                }
                else
                {
                    Console.WriteLine("Victory!");
                }
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
            
        }
    }
}
