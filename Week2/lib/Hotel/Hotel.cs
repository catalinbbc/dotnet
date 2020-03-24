using System;
using System.Collections.Generic;

namespace Hotel
{
    public class Hotel
    {

        private String name;
        private String city;

        private Dictionary<int, String> rooms = new Dictionary<int, String>();
        private KeyValuePair<int, String> room = new KeyValuePair<int, string>();

        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public String City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
            }
        }

        public Dictionary<int, String> Rooms { get; set; }
        public KeyValuePair<int, String> Room { get; set; }

        public double GetPriceForNumberOfRooms(int  numberOfRooms)
        {
            double baseRoomPrice = 55.12;

            return numberOfRooms * numberOfRooms;
        }

        public void Print()
        {
            
            Console.WriteLine($"Hotel Name {this.Name} from city {this.City} has the following rooms:");
            

        }
    }
}
