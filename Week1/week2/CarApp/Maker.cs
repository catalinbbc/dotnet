using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarApp
{
    class Maker : IMaker
    {
        public Dictionary<string, IVehicle> inventory;

        string readyTime;
        protected string make;



        public string Make { get => make; set => make = value; }
        public string ReadyTime { get => readyTime; set => readyTime = value; }

        public Maker()
        {
            this.inventory = new Dictionary<string, IVehicle>();
        }
        //public Dictionary<string, IVehicle> Inventory { get => inventory; set => inventory = value; }
        public IVehicle? GetCars(string make, string model, int year)
        {
            Dictionary<string, IVehicle> availableCars = new Dictionary<string, IVehicle>();
            foreach (KeyValuePair<string, IVehicle> car in inventory)
            {


                if (car.Value.Make.Equals(make) && car.Value.Model.Equals(model) && car.Value.Year.Equals(year))
                {
                    //availableCars.Add(car.Key, car.Value);
                    //return first found
                    return car.Value;
                }

            }


            return null;
            //return availableCars;
        }
        
        public void Sell(IVehicle car)
        {
            inventory.Remove(car.ID);
        }

        public string GetReadyTime()
        {
            return readyTime;
        }
    }
}
