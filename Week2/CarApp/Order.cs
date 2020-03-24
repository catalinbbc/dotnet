using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    class Order : IOrder
    {
        private string   carDetails;
        private decimal  price;
        private string   readyTime;
        private IVehicle car;
        private IPerson  customer;
        private int orderId;
        private bool delivered;
        private bool cancelled;


        public int OrderId { get => orderId; set => orderId = value; }
        public string CardDetails { get => carDetails; set => carDetails = value; }
        public decimal Price { get => price; set => price = value; }        
        public string ReadyTime { get => readyTime; set => readyTime = value; }
        public IVehicle Car { get => car; set => car = value; }
        public IPerson Customer { get => customer; set => customer = value; }
        public bool Delivered { get => delivered; set => delivered = value; }

        public bool Cancelled { get => cancelled; set => cancelled = value; }

    }
}
