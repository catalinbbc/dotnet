using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    interface IMaker
    {

        public string Make { get; set; }
        public IVehicle GetCars(string make, string model, int year);
        public string GetReadyTime();
        public void Sell(IVehicle car);
    }
}
