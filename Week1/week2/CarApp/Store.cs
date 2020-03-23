using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    class Store : IStore
    {
        private List<IOrder> orders;
        private string name;

        private Maker dealer;



        
        public string Name { get => name; set => name = value; }

        public Maker Dealer { get =>dealer; set => dealer = value; }

        public Store(string name)
        {
            this.name = name;
            orders = new List<IOrder>();
        }

        public IVehicle? GetCars(string make, string model, int year)
        {
            IVehicle car = this.dealer.GetCars(make, model, year);
            if (car == null)
            {                
                Console.WriteLine("No Car Found like Make: "+ make + " Model: "+model+ " Year: ");
                
            }
            return car;
        }

        public string getReadyTime()
        {
            return this.Dealer.GetReadyTime();
        }
        public void MakeOrder(IPerson customer, IVehicle car, decimal price, string readyTime)
        {
            Order order = new Order();
            order.CardDetails = car.Make + " - " + car.Model + " - " + car.Year + "-" + car.VIN;
            order.Price = price;
            order.ReadyTime = readyTime;
            order.Customer = customer;
            order.Car = car;
            Random rnd = new Random();
            order.OrderId = rnd.Next(10, 100);

            Console.WriteLine("\nMade a New Order: #"+order.OrderId+": Details = "+order.CardDetails + "Price: "+order.Price+" Delivered In "+order.ReadyTime);
            Console.WriteLine();
            orders.Add(order);
        }

        public void PickUpCar(int orderId)
        {
            bool foundOrder = false;
            foreach (Order curentOrder in orders)
            {
                if (curentOrder.OrderId.Equals(orderId))
                {   
                    curentOrder.Delivered = true;
                    Console.WriteLine("Order : "+curentOrder.OrderId + "was delivered");
                    foundOrder = true;
                }

            }

            if(!foundOrder)
            {
                Console.WriteLine("Order: "+orderId + "was not found");
            }
        }


        public void CancelOrder(int orderId)
        {
            bool foundOrder = false;

            foreach (Order curentOrder in orders)
            {
                if (curentOrder.OrderId.Equals(orderId))
                {
                    //orders.Remove()
                    curentOrder.Cancelled = true;
                    Console.WriteLine("Order : " + curentOrder.OrderId + "was CANCELLED ");
                    foundOrder = true;
                }

            }

            if (!foundOrder)
            {
                Console.WriteLine("Order: " + orderId + "was not found");
            }
        }
    
    }
}
