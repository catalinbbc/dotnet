using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    interface IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public decimal Price { get; set; }  
        public string ID { get; set; }
    }
}
