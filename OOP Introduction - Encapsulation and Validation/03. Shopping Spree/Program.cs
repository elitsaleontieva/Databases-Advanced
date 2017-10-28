using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            // var command = Console.ReadLine();
            var inputLine1 = Console.ReadLine();
            var inputLine2 = Console.ReadLine();

            var chars = ";".ToArray();
            var nameMoney = inputLine1.Trim().Split(chars, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var nameCost = inputLine2.Trim().Split(chars, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var chars2 = "=".ToArray();

            foreach (var item in nameMoney)
            {
                var res = item.Split(chars2, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = res[0];
                var money = decimal.Parse(res[1]);
                try
                {
                    persons.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            foreach (var item in nameCost)
            {
                var res = item.Split(chars2, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var product = res[0];
                var cost = decimal.Parse(res[1]);
                try
                {
                    products.Add(new Product(product, cost));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }

            var command = Console.ReadLine();
            while (command != "END")
            {
                var parts = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var name = parts[0];
                var productName = parts[1];

                Person person = persons.Where(p => p.Name == name).First();
                Product product = products.Where(p => p.Name == productName).First();

                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.AddProductToBag(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");

                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                command = Console.ReadLine();
            }

            foreach (Person person in persons)
            {
                if (person.GetBag().Count > 0)
                {
                    foreach (var productsBought in person.GetBag())
                    {

                        Console.WriteLine($"{person.Name} - {productsBought.Name}");
                    }
                  //  Console.WriteLine($"{person.Name} - {String.Join(", ", person.GetBag().Select(p => p.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
