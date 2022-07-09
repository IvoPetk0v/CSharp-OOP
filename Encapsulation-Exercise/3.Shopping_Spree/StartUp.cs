using _3.Shopping_Spree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Shopping_Spree
{
    class StartUp
    {
        static void FillTheLists(List<Person> personList, List<Product> productList, string[] personArgs, string[] productArgs)
        {
            for (int i = 0; i < personArgs.Length; i++)
            {
                string[] prsArgs = personArgs[i].Split("=",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = prsArgs[0];
                decimal money = decimal.Parse(prsArgs[1]);
                try
                {
                    Person newPerson = new Person(name, money);
                    personList.Add(newPerson);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    Environment.Exit(0);
                }
            }
            for (int i = 0; i < productArgs.Length; i++)
            {
                string[] prodArgs = productArgs[i].Split("=",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = prodArgs[0];
                decimal cost = decimal.Parse(prodArgs[1]);
                try
                {
                    Product newProduct = new Product(name, cost);
                    productList.Add(newProduct);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    Environment.Exit(0);
                }
            }
        }
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            string[] personArgs = Console.ReadLine().Split(";");
            string[] productArgs = Console.ReadLine().Split(";");

            FillTheLists(personList, productList, personArgs, productArgs);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmds = input.Split().ToArray();
                string clientName = cmds[0];
                string productName = cmds[1];
                Person currPerson = personList.FirstOrDefault(x => x.Name == clientName);
                Product currProduct = productList.FirstOrDefault(x => x.Name == productName);
                if (currPerson.Money >= currProduct.Cost)
                {
                    currPerson.BuyProduct(currProduct);
                    Console.WriteLine($"{clientName} bought {productName}");
                  
                }
                else
                {
                    Console.WriteLine($"{clientName} can't afford {productName}");
                }
            }
            foreach (var person in personList)
            {
                Console.WriteLine(person);
            }

        }
    }
}
