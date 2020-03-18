using System;
using System.Collections.Generic;
using System.IO;

namespace HotelApp
{
    public class Hotel
    {

        private String name;
        private String city;

        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();
        private KeyValuePair<int, Room> room = new KeyValuePair<int, Room>();

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

        public Dictionary<int, Room> Rooms { get; set; }
        public KeyValuePair<int, Room> Room { get; set; }


        public void GetPriceForNumberOfRooms(int numberOfRooms)
        {
            decimal price = 0;
            if (numberOfRooms > Rooms.Count)
            {
                throw new Exception("The number of rooms is less than the invetory!");
            }
            foreach (KeyValuePair<int, Room> currentRoom in Rooms)
                {
                    
                    Console.WriteLine("Price for room:{0} x {1} is {2}", currentRoom.Value.Name, numberOfRooms, currentRoom.Value.GetRateAmount()) ;
                }

        }

        public void GetRoomsUnderBuget(decimal maxAmount)
        {
            int atLeastOne = 0;
            if (maxAmount < 0)
            {
                throw new Exception("The Budget must be a positive amount");
            }
            foreach (KeyValuePair<int, Room> currentRoom in Rooms)
            {
                decimal roomPrice = currentRoom.Value.GetRateAmount();
                if (roomPrice <= maxAmount)
                {
                   Console.WriteLine("Room: {0} - Price: {1}", currentRoom.Value.Name, roomPrice);
                    atLeastOne++;
                }
            }
            if(atLeastOne == 0)
            {
                Console.WriteLine("There is no room under that price");
            }

        }

        public void Print()
        {
            
            Console.WriteLine($"Hotel Name {this.Name} from city {this.City} has the following rooms:");

            foreach (KeyValuePair<int, Room> room in rooms)
            {
                //Console.WriteLine($"Room Id:{room.Value}");
                room.Value.Print();
            }            

        }


        public void PopulateHotels()
        {

        }


        public void PopulateRooms(out Dictionary<int, Room> myRooms)
        {
            myRooms = new Dictionary<int, Room>();

            Room newRoom = new Room();
            newRoom.DefineRoom(ref  newRoom,"Deluxe Room",70,20,"EUR",2,1);
            //newRoom.Print();
            myRooms.Add(1, newRoom);


           
            Room newRoom2 = new Room();
            newRoom2.DefineRoom(ref newRoom2, "Simple Room", 40, 10, "EUR", 2, 0);
            //newRoom2.Print();
            myRooms.Add(2, newRoom2);
        }

        


    }
}
