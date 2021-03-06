﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class Person
    {
        //    Create two classes: class Person and class Product. Each 
        //        person should have a name, money and a bag of products.
        //Each product should have name and price.
        //        The name cannot be an empty string. 
        //The price cannot be negative or zero.

        private string name;
        private decimal money;
        private List<Product> bag;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }

          private set
            {
                if (value==string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

           set
            {

                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void AddProductToBag(Product product)
        {
            this.bag.Add(product);
        }

        public List<Product> SeeBag()
        {
            return this.bag;
        }
        


    }
}
