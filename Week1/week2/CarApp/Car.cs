using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    public class Car : IVehicle
    {
       
            private string make;
            private string model;
            private int year;
            private string vin;
            private decimal price;
            private string id;

            public string Make
            {
                get { return this.make; }
                set { this.make = value; }
            }

            public string Model
            {
                get { return this.model; }
                set { this.model = value; }
            }

            public int Year
            {
                get { return this.year; }
                set { this.year = value; }
            }

            public string VIN
            {
                get { return this.vin; }
                set { this.vin = value; }
            }
            public decimal Price
            {
                get { return this.price; }
                set { this.price = value; }
            }

            public string ID
            {
                get { return this.id; }
                set { this.id = value; }
            }


    }
}
