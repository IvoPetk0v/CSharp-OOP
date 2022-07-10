using _6.Food_Shortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebelers = new List<Rebel>();
            int n = int.Parse(Console.ReadLine());
            ReadPopulation(n, rebelers, citizens);
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (rebelers.Exists(x => x.Name == input))
                {
                    rebelers.Find(x => x.Name == input).BuyFood();
                }
                else if (citizens.Exists(x => x.Name == input))
                {
                    citizens.Find(x => x.Name == input).BuyFood();
                }
            }
            int boughtFood = rebelers.Sum(x => x.Food) + citizens.Sum(y => y.Food);
            Console.WriteLine(boughtFood);
        }
        static void ReadPopulation(int n, List<Rebel> rebelers, List<Citizen> citizens)
        {
            for (int i = 0; i < n; i++)
            {
                string[] personalData = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (personalData.Length == 4)
                {
                    string name = personalData[0];
                    int age = int.Parse(personalData[1]);
                    string id = personalData[2];
                    string birthday = personalData[3];
                    Citizen currPerson = new Citizen(name, age, id, birthday);
                    citizens.Add(currPerson);
                }
                else
                {
                    string name = personalData[0];
                    int age = int.Parse(personalData[1]);
                    string group = personalData[2];
                    Rebel currRebel = new Rebel(name, age, group);
                    rebelers.Add(currRebel);
                }
            }
        }
    }
}
