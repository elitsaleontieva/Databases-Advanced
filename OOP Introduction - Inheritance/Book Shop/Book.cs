using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication100
{
    class Book
    {

        private String title;
        private String author;
        private decimal price;


        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (value.Contains(' '))
                {
                    var valueString = value.Split(' ');



                    var firstLetter = valueString[1].Take(1);
                    if (char.IsDigit(firstLetter.First()))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");

                }
                this.title = value;
            }
        }


        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}" + Environment.NewLine +
                $"Title: {this.Title}" + Environment.NewLine +
                $"Author: {this.Author}" + Environment.NewLine +
                $"Price: {this.Price:f2}";
        }



    }
}
