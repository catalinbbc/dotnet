using System;
using System.Collections.Generic;
using System.Text;


namespace HotelApp
{
   public class Room
    {
        private String name;
        private Rate rate;
        private int adults;
        private int children;

        public String Name { get; set; }
        public Rate Rate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }

        public decimal GetPriceForDays(int numberOfDays)
        {
            return this.Rate.Amount * numberOfDays;
        }

        public decimal GetRateAmount()
        {
            return this.Rate.Amount;
        }

        public void Print()
        {
            Console.WriteLine($"Room Name: {this.Name} can contain {this.Adults} Adults and {this.Children} Childeren: pricePerNight: {this.GetPriceForDays(1)}");
        }

        public void DefineRoom( ref Room theRoom, String name, decimal adultPrice, decimal childPrice, String currency, int adults, int children)
        {
           
            Rate theRatePerAdult = new Rate();
            Rate theRatePerChild = new Rate();

            theRatePerAdult.Amount = adultPrice;
            theRatePerChild.Amount = childPrice;
            theRatePerAdult.Currency = currency;



            theRoom.Name = name;
            theRoom.Adults = adults;
            theRoom.Children = children;


            decimal price = (theRoom.Adults * theRatePerAdult.Amount) + (theRoom.Children * theRatePerChild.Amount);
            theRoom.Rate = new Rate();


            theRoom.Rate.Amount = price;
            theRoom.Rate.Currency = theRatePerAdult.Currency;
        }

    }
}
