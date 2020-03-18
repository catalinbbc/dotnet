using System;
using System.Collections.Generic;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hotel App");


            //define Hotel
            Hotel theHotelList = new Hotel();



            theHotelList.Name = "My Fancy Hotel";
            theHotelList.City = "Iasi";

            Dictionary<int, Room>  generatedRooms = new Dictionary<int, Room>();
            theHotelList.PopulateRooms(out generatedRooms);
            theHotelList.Rooms = generatedRooms;

            
           
            theHotelList.Print();
            foreach (KeyValuePair<int, Room> currentRoom in generatedRooms)
            {                
                currentRoom.Value.Print();
            }

            ////// Menu ///
            try
            {

             //calculate by the number of rooms       
            Console.WriteLine("Get number of rooms:");
            if (int.TryParse(Console.ReadLine(), out int numberOfRooms))
            {
                 theHotelList.GetPriceForNumberOfRooms(numberOfRooms);
                
            }
            else
            {
                Console.WriteLine("Invalid number of rooms!");
            }


            //calculate by number of days
            Console.WriteLine("Get number of days:");
            if (int.TryParse(Console.ReadLine(), out int numberOfDays))
            {
                Console.WriteLine("Prices for rooms are:");
                foreach (KeyValuePair<int, Room> currentRoom in generatedRooms)
                {
                    Console.WriteLine("\t {0} - {1} {2}", currentRoom.Value.Name, currentRoom.Value.GetPriceForDays(numberOfDays), currentRoom.Value.Rate.Currency);
                }
            }
            else
            {
                Console.WriteLine("Number of days must be a valid number 1-10");
            }

                //calculate rooms below a max buget
                Console.WriteLine("Get buget amount:");
                if (decimal.TryParse(Console.ReadLine(), out decimal maxAmount))
                {
                    Console.WriteLine("Rooms with price below {0}:",maxAmount);
                    theHotelList.GetRoomsUnderBuget(maxAmount);

                }
                else
                {
                    Console.WriteLine("Number of days must be a valid number 1-10");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
    }
}
