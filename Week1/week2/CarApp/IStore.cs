using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    interface IStore
    {
        public string Name { get; set; }
        public IVehicle GetCars(string make, string model, int year);
        public void MakeOrder(IPerson customer, IVehicle car, decimal price, string deliverTime);      
        public void PickUpCar(int OrderId);
        public void CancelOrder(int OrderId);
    }
}
