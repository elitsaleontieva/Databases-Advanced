using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Car
    {
        public String Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double DistanceTraveled { get; set; }

     
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            //you will receive information for a car in the following 
            //format “<Model> <FuelAmount> <FuelConsumptionFor1km>”
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.DistanceTraveled = 0; //all cars start at 0 kilometers traveled.
        }
      
        public bool Move(double distance)
        {
            
            double fuelNeeded = distance * this.FuelConsumption;
            if (this.FuelAmount<fuelNeeded)
            {
                //if a car can't move
                return false;
            }
          
            
            //if a car can move
            this.FuelAmount -= fuelNeeded;   // fuel amount should be reduced by the amount of used fuel and its 

            this.DistanceTraveled += distance;   //  distance traveled should be increased by the amount of kilometers traveled, 
            return true;
        }
    }
