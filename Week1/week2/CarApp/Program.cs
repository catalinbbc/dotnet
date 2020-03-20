using System;
using System.Collections.Generic;

namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 1;
            int selectedStoreId = 1;//default store

            Store s1 = new Store(); //FORD Store
            Store s2 = new Store();//Skoda store
            List<Store> StoreList = new List<Store>();

            StoreList.Add(s1);
            StoreList.Add(s2);

            Store selectedStore = new Store();

            do
            {

                choice = readInput();

            switch(choice)
                {
                    case 0:
                        Console.WriteLine("Exiting..........");
                        break;

                    case 1:
                        //chose the store
                        selectedStoreId = choice;
                        //if (StoreList[selectedStoreId] is Store)
                        break;

                    case 2:
                        //add a car to the selected store
                        Console.WriteLine("Please enter details for the new car of the :");
                        break;

                    default:
                        Console.WriteLine("Invalid Selection :" + choice);
                        break;
                }

            
            
            
            
            
            } while (choice != 0);




            Car c = new Car("Ford", "Focus", 15000);
            Car d = new Car("Ford", "Mustang", 35000);
            Car e = new Car("Ford", "Ka", 7500);


            Store s = new Store();
            s.Cars.Add(c);
            s.Cars.Add(d);
            s.Cars.Add(e);
        
        
        
        
        }


        static public int readInput()
        {
            int choice = 0;
           
            Console.WriteLine("Please enter an option:");
            Console.WriteLine("1 - Choose a store Ford = 1/ Skoda = 2");

           

            Console.WriteLine("2 - add a car to the invetory ");
           
            Console.WriteLine("3 - list cars from the current store inventory ");
            Console.WriteLine("4 - order a carfrom inventory ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return choice;

        }
    }
}
