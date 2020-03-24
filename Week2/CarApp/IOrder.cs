using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    interface IOrder
    {
        interface IOrder
        {
            public int OrderId { get; set; }
            public string CarDetails { get; set; }
            public decimal Price { get; set; }
            public string ReadyTime { get; set; }
            public IVehicle Car { get; set; }
            public IPerson Customer { get; set; }
            public int Delivered { get; set; }
            public int Cancelled 
            {
                get; set;
            }
        }
    }
}
