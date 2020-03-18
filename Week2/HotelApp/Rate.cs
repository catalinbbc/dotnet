using System;

namespace HotelApp
{
    public class Rate
    {
        private decimal amount;
        private String currency;

        public decimal Amount { get; set; }
        public String Currency { get; set; }

        public void Print()
        {
            Console.WriteLine($"Rate: {this.Amount} {this.Currency}");
        }


    }
}
