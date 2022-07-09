using System.Collections;

namespace _3.Shopping_Spree.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        private Person()
        {
            bagOfProducts = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            this.bagOfProducts.Add(product);
            this.money -= product.Cost;
        }
        public override string ToString()
        {
            string products;
            if (bagOfProducts.Count > 0)
            {
                products = string.Join(", ", bagOfProducts);
            }
            else
            {
                products = "Nothing bought";
            }

            return $"{this.Name} - " + products;
        }
    }
}

