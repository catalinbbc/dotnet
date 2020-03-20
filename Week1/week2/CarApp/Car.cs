using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    public class Car
    {

        public string Make { get; set; }
        public string Model { get; set; } 
        public decimal Price { get; set; }

        public Car()
        {
            Make = "New Car";
            Model = "No Model";
            Price = 1.00M;
        }

        public Car (string make, string model, decimal price)
        {
            Make = make;
            Model = model;
            Price = price;
        }
    }
}
