sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
               var input = Console.ReadLine().Split();
                var model = input[0];
                var fuelAmount=double.Parse(input[1]);
                var fuelConsumption= double.Parse(input[2]);

                if (!cars.Any(c=> c.Model ==model))
                {
                    var newCar = new Car(model,fuelAmount,fuelConsumption);
                    cars.Add(newCar); //add the car to the list
                }

             
            }

           var command=string.Empty;
            while ((command=Console.ReadLine()) != "End")
            {
                var parts = command.Split();
                var model = parts[1];
                var distance = double.Parse(parts[2]);

                Car car = cars.Find(c => c.Model == model); //if there is a car in the list of cars

               bool isMoved= car.Move(distance);

                if (!isMoved)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

           
            }

            foreach ( var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
