using System;

namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Ex #8: Electricity bill of a given customer:");
            Console.WriteLine("\nPlease the customer ID, Name, Units consumer:");
            Console.Write("\nEnter CustomerId:");
            var customerId = Console.ReadLine();

            Console.Write("\nEnter customer Name:");
            var customerName = Console.ReadLine();



            Console.Write("\nEnter units consumed:");
            var unitsConsumed = Int32.Parse(Console.ReadLine());

            double result = 0;
            double unitPrice = 0;
            double billAmount = 0;
            double penaltyAmount = 0;
            double NetbillAmount = 0;


            //check the bill amount based on units consumed
            if (unitsConsumed < 0)
            {
                unitPrice = 0;
            }
            else if (unitsConsumed <= 199)
            {
                unitPrice = 1.20;
            }
            else if (unitsConsumed > 199 && unitsConsumed < 400)
            {
                unitPrice = 1.50;
            }
            else if (unitsConsumed >= 400 && unitsConsumed < 600)
            {
                unitPrice = 1.80;
            }
            else if (unitsConsumed > 600)
            {
                unitPrice = 2.00;
            }


            //bill without surcharge
            billAmount = unitsConsumed * unitPrice;

            if (unitsConsumed >= 400)
            {
                penaltyAmount = billAmount * 15 / 100;
            }


            NetbillAmount = billAmount + penaltyAmount;

            Console.WriteLine("##################################################### ");
            Console.WriteLine("\nCustomer IDNO :" + customerId);
            Console.WriteLine("Customer Name :" + customerName);
            Console.WriteLine("Units Consumed :" + unitsConsumed);
            Console.WriteLine("Amount Charges @Rs. "+ unitPrice + " per unit : " + unitsConsumed);
            Console.WriteLine("Surchage Amount :" + penaltyAmount);
            Console.WriteLine("Net Amount Paid By the Customer:" + NetbillAmount);
            Console.WriteLine("##################################################### ");





        }
    }
}
