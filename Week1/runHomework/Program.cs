using System;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 exNumber = 0;
            
            do
            {
                //Console.Clear();
                Console.WriteLine("\n\n\nPlease enter an exercise number 1-6 or 0 to exit:");
                exNumber = Int32.Parse(Console.ReadLine());
                //Console.WriteLine("Selected exercise: " + exNumber);

                switch (exNumber)
                {
                    case 0:
                        Console.WriteLine("Exiting..........");
                        break;
                    case 1:
                        Excercise1.goex1();
                        break;

                    case 2:
                        Excercise2.goex2();
                        break;
                    case 3:
                        Excercise3.goex();
                        break;

                    case 4:
                        Excercise4.goex();
                        break;

                    case 5:
                        Exercise5.goex();
                        break;

                    case 6:
                        Exercise6.goex();
                        break;


                    default:
                        Console.WriteLine("Invalid Selection :" + exNumber);
                        break;
                }
                // code block to be executed
            } while (exNumber > 0 && exNumber <= 6);





        }
    }
}
