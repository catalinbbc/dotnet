using System;
using System.Collections.Generic;

namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //define dealers
            Store storeFord = new Store("Ford Iasi");

            storeFord.Dealer = new Maker();
            storeFord.Dealer.Make = "FORD";
            storeFord.Dealer.ReadyTime = "30 days"; 
            IVehicle car1 = new Car();
            car1.ID = "C1";
            car1.Make = "Ford";
            car1.Model = "Focus";
            car1.Year = 2020;
            car1.Price = 17500;
            car1.VIN = "UUDSKWLI12FF331";
            storeFord.Dealer.inventory.Add(car1.ID, car1);

            Store storeSkoda = new Store("Skoda Iasi");
            storeSkoda.Dealer = new Maker();
            storeSkoda.Dealer.Make = "SKODA";
            storeSkoda.Dealer.ReadyTime = "21 days";

            IVehicle car2 = new Car();
            car2.ID = "C2";
            car2.Make = "Skoda";
            car2.Model = "Octavia 4";
            car2.Year = 2020;
            car2.Price = 15500;
            car2.VIN = "SKDAA002020FVAS";
            storeSkoda.Dealer.inventory.Add(car2.ID, car2);


            //customer 
            Customer customer = new Customer("Alex TheClient", "07233244234", "C1533");

            IVehicle FordOffer = storeFord.GetCars("Ford", "Focus", 2020);
            string fordDeliveryTime = storeFord.getReadyTime();


            IVehicle SkodaOffer = storeSkoda.GetCars("Skoda", "Octavia 4", 2020);
            string skodaDeliveryTime = storeSkoda.getReadyTime();


            int choice = 0;

            int orderId = 0;
            do
            {

               choice = readInput();

            switch(choice)
                {
                    case 0:
                        Console.WriteLine("Exiting..........");
                        break;

                    case 1:
                       

                        if(FordOffer != null)
                        {
                            Console.WriteLine("Ford Offer:");
                            Console.WriteLine("Ford Car:#"+FordOffer.ID+" Model: "+ FordOffer.Model +" Year : "+FordOffer.Year+" Price:"+FordOffer.Price +" Delivered in "+fordDeliveryTime);
                        }
                            
                        break;

                    case 2:
                        
                        if (SkodaOffer != null)
                        {
                            Console.WriteLine("Skoda Offer:");
                            Console.WriteLine("Skoda Car:#" + SkodaOffer.ID + " Model: " + SkodaOffer.Model + " Year : " + SkodaOffer.Year + " Price:" + SkodaOffer.Price + " Delivered in " + skodaDeliveryTime);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter Id of the car you want to buy");
                        string carId = Console.ReadLine();
                        //to do validation and a method to search in stores inventary 
                        
                        //search in ford
                        if(carId == FordOffer.ID)
                        {
                          storeFord.MakeOrder(customer, FordOffer, 17100, fordDeliveryTime);
                        }
                        else if (carId == SkodaOffer.ID)
                        {
                           storeSkoda.MakeOrder(customer, SkodaOffer, 15100, skodaDeliveryTime);
                        }
                        else
                        {
                            Console.WriteLine( "Invalid CarId ..");
                        }

                        break;


                    case 4:
                        Console.WriteLine("Enter Id of the order to cancel");
                         orderId = int.Parse(Console.ReadLine());

                        //to do validation and a method to search in store orders 

                        if(orderId > 0)
                        {
                            //search in Ford 
                            storeFord.CancelOrder(orderId);
                            //search in skoda
                        }    
                        
                        break;

                    default:
                        Console.WriteLine("Invalid Selection :" + choice);
                        break;
                }

            
            
            
            
            
            } while (choice != 0);
            


        }


        static public int readInput()
        {
            int choice = 0;
           
            Console.WriteLine("Please enter an option:");
            Console.WriteLine("1 - view Ford Offers");
            Console.WriteLine("2 - view Skoda Offers");

            Console.WriteLine("3 - make an order");
            Console.WriteLine("4 - cancel an order");

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
