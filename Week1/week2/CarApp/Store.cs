using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    class Store
    {
        public List<Car> Cars { get; set; }
        public List<Car> Orders { get; set; }
    
        public Store()
        {
            Cars    = new List<Car>();
            Orders  = new List<Car>();

        }

        public decimal Sell()
        {
            decimal totalCost = 0;

            foreach(var c in Cars)
            {
                if(c.Make == "Ford" && c.Model == "Focus 2020")
                {
                    totalCost =  c.Price;

                    int orderId = Orders.Count + 1;
                    Orders[orderId] = c;
                }
            }

            return totalCost;

        }
    
    }
}
