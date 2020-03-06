using System;

namespace ex2
{
    class ex2
    {
        static void Main(string[] args)
        {
            
             char[]  allowedOperations = new char[] { '+', '-', '*', '/' };
             int length = allowedOperations.Length;
            
            Console.WriteLine("Allowed Operations:");
            for (int index = 0; index < length; index++)
            {
                Console.Write(allowedOperations[index] + " ");
            }

                Console.WriteLine("\nPlease enter 2 numbers and an operation eg a + b:\n");
           

            Console.WriteLine("Enter first number:");
            var firstElement = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter operation:");
            var operation = Console.ReadLine();

           

            Console.WriteLine("Enter second number:");
            var secondElement = Int32.Parse(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case "-":
                    result = firstElement - secondElement;
                    break;

                case "+":
                    result = firstElement + secondElement;
                    break;

                case "/":
                    if (secondElement > 0)
                        result = firstElement / secondElement;
                    else
                        result = 0;
                    break;

                case "*":
                case "x":
                    result = firstElement * secondElement;
                    break;

                default:
                    Console.WriteLine("\n Wrong operation entered: "+ operation);
                    return;
                    break;                  
            }

           
            Console.WriteLine(firstElement + " " + operation + " " + secondElement  + " = " + result);









        }
    }
}
